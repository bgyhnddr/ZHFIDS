using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace MYSQLTest
{
    public partial class TestForm : Form
    {
        private delegate void MYEventHandler();
        private DataTable TestTable;
        private List<Thread> ThreadList = new List<Thread>();
        private bool stop = false;
        public TestForm()
        {
            InitializeComponent();
            SFileDialog.InitialDirectory = OFileDialog.InitialDirectory = Application.StartupPath;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SFileDialog.ShowDialog();
        }

        private void SFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var table = new DataTable();
            table.Columns.Add("sql");
            table.Columns.Add("interval");
            var row = table.NewRow();
            row["sql"] = "SELECT * FROM `zh-fids`.departure;";
            row["interval"] = "15";
            table.Rows.Add(row);
            File.WriteAllText(SFileDialog.FileName, CSVHelper.MakeCSV(table), Encoding.UTF8);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OFileDialog.ShowDialog();
        }

        private DataTable InitData(DataTable table)
        {
            TestTable = new DataTable();
            TestTable.Columns.Add("sql");
            TestTable.Columns.Add("interval");
            TestTable.Columns.Add("requestTime");
            foreach (DataRow row in table.Rows)
            {
                var newRow = TestTable.NewRow();
                newRow["sql"] = row["sql"];
                newRow["interval"] = row["interval"];
                newRow["requestTime"] = string.Empty;
                TestTable.Rows.Add(newRow);
            }

            return TestTable;
        }

        private void OFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                TestTable = InitData(CSVHelper.ReadCSVToTable(OFileDialog.FileName, Encoding.UTF8));
                dgvShow.DataSource = TestTable;
            }
            catch
            {
                MessageBox.Show("读取文件出错");
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            stop = false;
            foreach(DataGridViewRow row in dgvShow.Rows)
            {
                try
                {
                    if (row.Cells["sql"].Value != null)
                    {
                        var newThread = new Thread(new ParameterizedThreadStart((o) =>
                            {
                                try
                                {
                                    var watch = new Stopwatch();
                                    var gridRow = (DataGridViewRow)o;
                                    while (!this.IsDisposed && !stop)
                                    {
                                        watch.Start();
                                        try
                                        {
                                            var conn = new MySql.Data.MySqlClient.MySqlConnection(data.FIDSAdapter.ConfigAdapter.Connection.ConnectionString);
                                            conn.Open();
                                            string sql = gridRow.Cells["sql"].Value.ToString();
                                            MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                                            var obj = comm.ExecuteScalar();
                                            conn.Close();
                                            var time = watch.ElapsedMilliseconds.ToString();
                                            this.Invoke(new MYEventHandler(() =>
                                            {
                                                gridRow.Cells["requestTime"].Value = time;
                                            }));
                                            Thread.Sleep(int.Parse(gridRow.Cells["interval"].Value.ToString()) * 1000);
                                        }
                                        catch (ThreadAbortException ex)
                                        {
                                            break;
                                        }
                                        catch (Exception ex)
                                        {
                                            this.Invoke(new MYEventHandler(() =>
                                            {
                                                gridRow.Cells["requestTime"].Value = ex.Message;
                                            }));
                                            Thread.Sleep(1000);
                                        }
                                        finally
                                        {
                                            watch.Stop();
                                            watch.Reset();
                                        }
                                    }
                                }
                                catch(ThreadAbortException ex)
                                {
                                }
                            }));
                        newThread.Start(row);
                    }
                }
                catch
                {

                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
