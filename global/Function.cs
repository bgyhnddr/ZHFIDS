using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using global.EOSFIDSReference;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace global
{
    public partial class Function
    {

        [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
        public static extern int ShowCursor(bool bShow);

        public static bool CheckMySQLConnection()
        {
            try
            {
                data.FIDSAdapter.ConfigAdapter.Connection.Open();
                data.FIDSAdapter.ConfigAdapter.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }


        public static string GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        }

        public static void CreateAccessTimer(System.Windows.Forms.Timer timer)
        {
            timer.Interval = Const.AccessTimerInterval;
            timer.Tick += new System.EventHandler((sender, e) =>
            {
                var conn = new MySql.Data.MySqlClient.MySqlConnection(data.FIDSAdapter.ConfigAdapter.Connection.ConnectionString);
                try
                {

                    conn.Open();
                    string sql = string.Format("UPDATE `zh-fids`.`ipcstatus` SET `lastaccesstime` = now() WHERE `ip` = '{1}';", global.Variable.IP.ToString());
                    MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();

                    //MySql.Data.MySqlClient.MySqlTransaction tran = null;
                    //var adapter = new data.FIDSDatasetTableAdapters.ipcstatusTableAdapter();

                    //adapter.Connection.Open();
                    //tran = adapter.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    //var rows = adapter.GetData().Where(o => o.ip == global.Variable.IP.ToString()).ToArray();
                    //if (rows.Length > 0)
                    //{
                    //    var row = rows[0];
                    //    row.lastaccesstime = DateTime.Now;
                    //    adapter.Update(row);
                    //}
                    //tran.Commit();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
            });
            timer.Enabled = true;
        }

        public static void CreateErrorImage(System.Windows.Forms.PictureBox pictureBoxMark)
        {
            var markpath = Application.StartupPath + "\\image\\mark.jpg";
            if (File.Exists(markpath))
            {
                System.Drawing.Bitmap destBmp = new Bitmap(Application.StartupPath + "\\image\\mark.jpg");
                pictureBoxMark.BackgroundImage = destBmp;
            }
            else
            {
                var CImage = new Bitmap(600, 300); // 创建一个52*52的Bitmap
                Graphics g = Graphics.FromImage(CImage);
                g.Clear(Color.FromArgb(0));
                pictureBoxMark.BackgroundImage = CImage;
            }
        }

        public static void CountErrorTime()
        {
            var config = data.FIDSAdapter.ConfigAdapter.GetData();
            var connected = bool.Parse(config.Where(o => o.code == Const.CONNECTEDCONFIG).First().value);
            var updateinterval = int.Parse(config.Where(o => o.code == Const.UPDATEINTERVALCONFIG).First().value);

            if (!connected && updateinterval > 0)
            {
                Variable.ERRORTIMECOUNT += 1;
            }
            else
            {
                Variable.ERRORTIMECOUNT = 0;
            }
        }

        /// <summary>
        /// 写操作
        /// </summary>
        /// <param name="appKey">项名</param>
        /// <param name="appValue">项值</param>
        public static void SetConfigValue(string appKey, string appValue)
        {
            XmlDocument xDoc = new XmlDocument();
            //获取可执行文件的路径和名称
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            var xNode = xDoc.SelectSingleNode("//appSettings");
            if (xNode != null)
            {
                var xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem1 != null) xElem1.SetAttribute("value", appValue);
            }

            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");


            //bool isModified = false;
            //foreach (string key in ConfigurationManager.AppSettings)
            //{
            //    if (key == appKey)
            //    {
            //        isModified = true;
            //    }
            //}
            //// Open App.Config of executable     
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);     // You need to remove the old settings object before you can replace it     
            //if (isModified)
            //{
            //    config.AppSettings.Settings[appKey].Value = appValue;
            //}
            //else
            //{
            //    // Add an Application Setting. 
            //    config.AppSettings.Settings.Add(appKey, appValue);        // Save the changes in App.config file. 
            //}
            //config.Save(ConfigurationSaveMode.Modified);     // Force a reload of a changed section. 
            //ConfigurationManager.RefreshSection("appSettings");
        }

        #region dynamic
        public static void GetFlightDynamicInterval()
        {
            var row = data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.UPDATEINTERVALCONFIG).ToArray();
            Variable.GetFlightDynamic_Interval = int.Parse(row[0].value);
        }

        public static void SetDynamicStatus(bool status)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var adapter = new data.FIDSDatasetTableAdapters.configTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();

                var row = adapter.GetData().Where(o => o.code == global.Const.CONNECTEDCONFIG).ToArray()[0];
                row.value = status.ToString();
                adapter.Update(row);
                tran.Commit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
        }

        public static void SetDynamicInterval()
        {
            var updateinterval = data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.UPDATEINTERVALCONFIG).ToArray()[0].value;

            var intervalstring = Microsoft.VisualBasic.Interaction.InputBox(global.Const.DYNAMICINTERVALTIPS, global.Const.DYNAMICINTERVALTITLE, updateinterval);
            if (!string.IsNullOrWhiteSpace(intervalstring))
            {
                SetDynamicIntervalTime(int.Parse(intervalstring));
            }
        }

        public static void SetDynamicIntervalTime(int interval)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var adapter = new data.FIDSDatasetTableAdapters.configTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var row = adapter.GetData().Where(o => o.code == global.Const.UPDATEINTERVALCONFIG).ToArray();
                global.Variable.GetFlightDynamic_Interval = interval * 1000;
                row[0].value = interval.ToString();
                adapter.Update(row[0]);
                tran.Commit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
                MessageBox.Show(global.Const.SAVEDATAERROR, ex.StackTrace);
            }
            finally
            {
                adapter.Connection.Close();
            }
        }

        public static bool SetDynamicRow(data.FIDSDataset.flightdynamicRow dyrow, Newtonsoft.Json.Linq.JToken row)
        {
            try
            {
                if (!dyrow.manual)
                {
                    string std = string.Empty,
                        etd = string.Empty,
                        atd = string.Empty,
                        sta = string.Empty,
                        eta = string.Empty,
                        ata = string.Empty;

                    if (row[Const.JSON_FROM_Code].ToString() == Const.ZUH)
                    {
                        std = row[Const.JSON_STD].ToString();
                        etd = row[Const.JSON_ETD] != null ? row[Const.JSON_ETD].ToString() : string.Empty;
                        atd = row[Const.JSON_ATD] != null ? row[Const.JSON_ATD].ToString() : string.Empty;
                    }
                    else if (row[Const.JSON_TO_Code].ToString() == Const.ZUH)
                    {
                        sta = row[Const.JSON_STA].ToString();
                        eta = row[Const.JSON_ETA] != null ? row[Const.JSON_ETA].ToString() : string.Empty;
                        ata = row[Const.JSON_ATA] != null ? row[Const.JSON_ATA].ToString() : string.Empty;
                    }


                    string via = string.Empty, en_via = string.Empty;
                    if (row[Const.JSON_VIA] != null)
                    {
                        foreach (var viaplace in row[Const.JSON_VIA])
                        {
                            if (viaplace[Const.JSON_VIA_code].ToString() == Const.ZUH)
                            {
                                std = viaplace[Const.JSON_STD].ToString();
                                etd = viaplace[Const.JSON_ETD] != null ? viaplace[Const.JSON_ETD].ToString() : string.Empty;
                                atd = viaplace[Const.JSON_ATD] != null ? viaplace[Const.JSON_ATD].ToString() : string.Empty;
                                sta = viaplace[Const.JSON_STA].ToString();
                                eta = viaplace[Const.JSON_ETA] != null ? viaplace[Const.JSON_ETA].ToString() : string.Empty;
                                ata = viaplace[Const.JSON_ATA] != null ? viaplace[Const.JSON_ATA].ToString() : string.Empty;
                                via += "*";
                                en_via += "*";
                            }

                            via += viaplace[Const.JSON_VIA_briefCn].ToString() + " ";
                            en_via += viaplace[Const.JSON_VIA_briefEn].ToString() + " ";
                        }
                    }

                    via += row[Const.JSON_TO_BriefCn].ToString();
                    en_via += row[Const.JSON_TO_BriefEn].ToString();

                    var counter = string.Empty;

                    counter = row[Const.JSON_counterArea] != null ? row[Const.JSON_counterArea].ToString() : string.Empty;




                    dyrow.flightdynamicid = row[Const.JSON_flightDynamicId].ToString();
                    dyrow.date = row[Const.JSON_date] != null ? row[Const.JSON_date].ToString() : string.Empty;


                    //获取航班
                    dyrow.flight = GetFlight(row[Const.JSON_SHARE], row[Const.JSON_FLIGHT].ToString());
                    dyrow.airlinecode = row[Const.JSON_airlinesCode] != null ? row[Const.JSON_airlinesCode].ToString() : string.Empty;



                    dyrow.from = row[Const.JSON_FROM_BriefCn].ToString();
                    dyrow.en_from = row[Const.JSON_FROM_BriefEn].ToString();
                    dyrow.tovia = via;
                    dyrow.en_tovia = en_via;
                    dyrow.std = std;
                    dyrow.etd = etd;
                    dyrow.atd = atd;
                    dyrow.sta = sta;
                    dyrow.eta = eta;
                    dyrow.ata = ata;
                    
                    dyrow.counter = counter.Trim();

                    var gate = row[Const.JSON_boardinGateCode] != null ? row[Const.JSON_boardinGateCode].ToString() : string.Empty;

                    if (!string.IsNullOrWhiteSpace(gate))
                    {
                        var alertGate = row[Const.JSON_alterBoardinGateCode] != null ? row[Const.JSON_alterBoardinGateCode].ToString() : string.Empty;
                        if(!string.IsNullOrWhiteSpace(alertGate))
                        {
                            gate += ">" + alertGate;
                        }
                    }

                    dyrow.gate = gate;
                    dyrow.carousel = row[Const.JSON_carouselCode] != null ? row[Const.JSON_carouselCode].ToString() : string.Empty;
                    dyrow.arrivalstatus = (row[Const.JSON_arrivalStatusCn]) != null ? (row[Const.JSON_arrivalStatusEn].ToString() != Const.Plan ? row[Const.JSON_arrivalStatusCn].ToString() : string.Empty) : string.Empty;
                    dyrow.en_arrivalstatus = row[Const.JSON_arrivalStatusEn] != null ? (row[Const.JSON_arrivalStatusEn].ToString() != Const.Plan ? row[Const.JSON_arrivalStatusEn].ToString() : string.Empty) : string.Empty;
                    dyrow.departstatus = (row[Const.JSON_departStatusCn]) != null ? (row[Const.JSON_departStatusEn].ToString() != Const.Plan ? row[Const.JSON_departStatusCn].ToString() : string.Empty) : string.Empty;
                    dyrow.en_departstatus = row[Const.JSON_departStatusEn] != null ? (row[Const.JSON_departStatusEn].ToString() != Const.Plan ? row[Const.JSON_departStatusEn].ToString() : string.Empty) : string.Empty;
                    dyrow.arrivaloutward = row[Const.JSON_arrivalOutwardCn] != null ? row[Const.JSON_arrivalOutwardCn].ToString() : string.Empty;
                    dyrow.arrivaloutward_en = row[Const.JSON_arrivalOutwardEn] != null ? row[Const.JSON_arrivalOutwardEn].ToString() : string.Empty;
                    dyrow.departoutward = row[Const.JSON_departOutwardCn] != null ? row[Const.JSON_departOutwardCn].ToString() : string.Empty;
                    dyrow.departoutward_en = row[Const.JSON_departOutwardEn] != null ? row[Const.JSON_departOutwardEn].ToString() : string.Empty;
                    dyrow.lastmodifytime = DateTime.Parse(row[Const.JSON_lastModifyTime].ToString());
                    if (row[Const.JSON_propertyCode].ToString() == "Q/B")
                    {
                        dyrow.forceshow = 2;
                    }
                    if (dyrow.std == string.Empty && dyrow.sta == string.Empty)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }

        private static string GetFlight(Newtonsoft.Json.Linq.JToken shares, string flight)
        {
            if (shares != null)
            {
                foreach (var viaplace in shares)
                {
                    flight += "," + viaplace[global.Const.JSON_flightCode];
                }
                return flight;
            }
            return flight;
        }
        public static bool StartGetDynamicThread(ToolStripMenuItem item)
        {
            try
            {
                if (Variable.GetDynamicThread != null)
                {
                    if (Variable.GetDynamicThread.IsAlive)
                    {
                        Variable.GetDynamicThread.Abort();
                    }
                }
                Variable.GetDynamicThread = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        try
                        {
                            global.Function.GetFlightDynamicInterval();
                            if (Variable.GetFlightDynamic_Interval != 0)
                            {
                                GetDynamic();
                                Thread.Sleep(Variable.GetFlightDynamic_Interval * 1000);
                            }
                            else
                            {
                                Thread.Sleep(1000);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.Message);
                        }
                    }
                }));
                Variable.GetDynamicThread.IsBackground = true;
                Variable.GetDynamicThread.Start();
                item.Checked = true;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.STARTAUTOGETDYNAMICERROR, ex));
                item.Checked = false;
                return false;
            }
        }

        public static bool StopGetDynamicThread(ToolStripMenuItem item)
        {
            try
            {
                if (Variable.GetDynamicThread != null)
                {
                    if (Variable.GetDynamicThread.IsAlive)
                    {
                        Variable.GetDynamicThread.Abort();
                    }
                }
                item.Checked = false;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.STOPAUTOGETDYNAMICERROR, ex));
                item.Checked = false;
                return false;
            }
        }
        
        private static bool UpdateDynamicByJSON(string JSON)
        {

            var success = false;
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var updateRows = new List<data.FIDSDataset.flightdynamicRow>();
            var adapter = new data.FIDSDatasetTableAdapters.flightdynamicTableAdapter();
            try
            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(JSON);
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var dyTable = adapter.GetData();
                List<string> ids = new List<string>();
                foreach (var row in ja)
                {
                    if (row[Const.JSON_propertyCode] == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (row[Const.JSON_propertyCode].ToString() != "W/Z" &&
                            row[Const.JSON_propertyCode].ToString() != "Z/P" &&
                            row[Const.JSON_propertyCode].ToString() != "C/B" &&
                            row[Const.JSON_propertyCode].ToString() != "Q/B")
                        {
                            continue;
                        }
                    }
                    if (row[Const.JSON_airlinesCode] != null && row[Const.JSON_flightDynamicId] != null && row[Const.JSON_lastModifyTime] != null)
                    {
                        ids.Add(row[Const.JSON_flightDynamicId].ToString());
                        if (row[Const.JSON_lastModifyTime] != null)
                        {
                            var lastModify = DateTime.Parse(row[Const.JSON_lastModifyTime].ToString());
                            data.FIDSDataset.flightdynamicRow dyrow;
                            var dyrows = dyTable.Where(o => o.flightdynamicid == row[Const.JSON_flightDynamicId].ToString()).ToArray();
                            if (dyrows.Length > 0)
                            {
                                dyrow = dyrows[0];
                                if (dyrow.lastmodifytime < lastModify)
                                {
                                    if (SetDynamicRow(dyrow, row))
                                    {
                                        try
                                        {
                                            updateRows.Add(dyrow);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dyrow = dyTable.NewflightdynamicRow();
                                dyrow.manual = false;

                                if (SetDynamicRow(dyrow, row))
                                {
                                    dyrow.forceshow = 0;
                                    if (row[Const.JSON_propertyCode].ToString() == "Q/B")
                                    {
                                        dyrow.forceshow = 2;
                                    }
                                    try
                                    {
                                        dyTable.AddflightdynamicRow(dyrow);
                                        updateRows.Add(dyrow);
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                if (updateRows.Count > 0)
                {
                    adapter.Update(updateRows.ToArray());
                }
                if (ids.Count > 0)
                {
                    DeleteDynamic(adapter.Connection, tran, ids);
                }



                tran.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);

                global.Variable.WEBSERVICEERROR = ex.Message;
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
            return success;
        }
        private static void GetDynamic()
        {
            try
            {
                var service = CreateService();
                GetFlightDynamicByWebService(service, (DateTime.Now - global.Variable.TIMESPLIT).ToString(Const.DATEFORMAT));
            }
            catch (Exception ex)
            {
                SetDynamicStatus(false);
                global.Variable.WEBSERVICEERROR = ex.Message;
                Debug.Print(ex.StackTrace);
            }
        }

        private static void GetFlightDynamicByWebService(ServicesBinding service, string date)
        {
            string outMsg, outStr;
            service.getFlightDynamic(date, null, null, out outMsg, out outStr);
            if(string.IsNullOrEmpty(outStr))
            {
                throw new Exception(global.Const.NODYNAMICDATA);
            }
            SetDynamicStatus(global.Function.UpdateDynamicByJSON(outStr));
        }

        public static string CheckDynamicByWebService(ServicesBinding service)
        {
            var returnMsg = string.Empty;
            try
            {
                string outMsg, outStr;

                global.Variable.TIMESPLIT = global.Function.GetTimeSplit();
                var nowTime = DateTime.Now - global.Variable.TIMESPLIT;
                var date = nowTime.ToString(global.Const.DATEFORMAT);
                returnMsg += date;
                service.getFlightDynamic(date, null, null, out outMsg, out outStr);
                if (string.IsNullOrEmpty(outStr))
                {
                    return returnMsg + global.Const.NODYNAMICDATA;
                }
            }
            catch (Exception ex)
            {
               returnMsg += ex.Message;
               return returnMsg;
            }
            return returnMsg + global.Const.DYNAMICNORMAL;
        }

        private static void DeleteDynamic(MySql.Data.MySqlClient.MySqlConnection connection, MySql.Data.MySqlClient.MySqlTransaction tran, List<string> ids)
        {
            string sql = "DELETE FROM `zh-fids`.`flightdynamic` WHERE flightdynamicid NOT IN ('" + string.Join("','", ids) + "') AND manual = false";
            MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(sql, connection, tran);
            comm.ExecuteNonQuery();
        }

        #endregion

        #region plan
        public static void GetFlightPlanByWebService(ServicesBinding service, string date)
        {
            try
            {
                string outMsg, outStr;
                service.getFlightDynamic(date, null, null, out outMsg, out outStr);
                var dayOfWeek = (int)DateTime.Parse(date).DayOfWeek;
                global.Function.UpdateFlightPlanByJSON(outStr, dayOfWeek);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                SetDynamicStatus(false);
                throw ex;
            }
        }

        private static bool UpdateFlightPlanByJSON(string JSON, int dayOfWeek)
        {
            var success = false;
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var updateRows = new List<data.FIDSDataset.flightplanRow>();
            var adapter = new data.FIDSDatasetTableAdapters.flightplanTableAdapter();
            try
            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(JSON);
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                DeletePlan(adapter.Connection, tran, dayOfWeek);
                var pTable = adapter.GetData();
                List<string> ids = new List<string>();
                foreach (var row in ja)
                {
                    var prows = pTable.Where(o => o.code == dayOfWeek.ToString() + "-" + row[Const.JSON_FLIGHT].ToString()).ToArray();
                    if (prows.Length > 0)
                    {
                        if (SetPlanRow(prows[0], row))
                        {
                            try
                            {
                                updateRows.Add(prows[0]);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        var planrow = pTable.NewflightplanRow();
                        planrow.code = dayOfWeek.ToString() + "-" + row[Const.JSON_FLIGHT].ToString();
                        planrow.day = dayOfWeek;
                        if (SetPlanRow(planrow, row))
                        {
                            try
                            {
                                pTable.AddflightplanRow(planrow);
                                updateRows.Add(planrow);
                            }
                            catch { }
                        }
                    }

                }
                if (updateRows.Count > 0)
                {
                    adapter.Update(updateRows.ToArray());
                }
                tran.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
            return success;
        }

        public static void StartGetPlanThread(ToolStripMenuItem item)
        {
            try
            {
                if (Variable.GetPlanThread != null)
                {
                    if (Variable.GetPlanThread.IsAlive)
                    {
                        Variable.GetPlanThread.Abort();
                    }
                }
                Variable.GetPlanThread = new Thread(new ThreadStart(() =>
                {
                    var service = CreateService();
                    var date = DateTime.Now - global.Variable.TIMESPLIT;
                    var init = true;
                    while (true)
                    {
                        try
                        {
                            if (date.DayOfWeek != (DateTime.Now - global.Variable.TIMESPLIT).DayOfWeek || init)
                            {
                                if (init == true)
                                {
                                    init = false;
                                }
                                date = DateTime.Now - global.Variable.TIMESPLIT;
                                GetFlightPlanByWebService(service, date.ToString(Const.DATEFORMAT));
                            }
                            Thread.Sleep(60000);
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.Message);
                        }
                    }

                }));
                Variable.GetPlanThread.IsBackground = true;
                Variable.GetPlanThread.Start();
                item.Checked = true;
            }
            catch (Exception ex)
            {
                item.Checked = false;
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.STARTAUTOGETPLANERROR, ex));
            }
        }

        public static bool StopGetPlanThread(ToolStripMenuItem item)
        {
            try
            {
                if (Variable.GetPlanThread != null)
                {
                    if (Variable.GetPlanThread.IsAlive)
                    {
                        Variable.GetPlanThread.Abort();
                    }
                }
                item.Checked = false;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.STOPAUTOGETPLANERROR, ex));
                item.Checked = false;
                return false;
            }
        }

        private static bool SetPlanRow(data.FIDSDataset.flightplanRow prow, Newtonsoft.Json.Linq.JToken row)
        {
            try
            {
                string std = string.Empty, sta = string.Empty, via = string.Empty, viaen = string.Empty;

                var viazuh = false;

                if (row[Const.JSON_VIA] != null)
                {
                    var zhuRow = row[Const.JSON_VIA].Where(o => o[Const.JSON_VIA_code].ToString() == Const.ZUH).ToArray();
                    if (zhuRow.Length > 0)
                    {
                        std = zhuRow[0][Const.JSON_STD].ToString();
                        sta = zhuRow[0][Const.JSON_STA].ToString();
                        via = string.Join(" ", row[Const.JSON_VIA].Select((o) =>
                        {
                            if (o[Const.JSON_VIA_code].ToString() == Const.ZUH)
                            {
                                return "*" + o[Const.JSON_VIA_briefCn];
                            }
                            else
                            {
                                return o[Const.JSON_VIA_briefCn];
                            }
                        }));

                        viaen = string.Join(" ", row[Const.JSON_VIA].Select((o) =>
                        {
                            if (o[Const.JSON_VIA_code].ToString() == Const.ZUH)
                            {
                                return "*" + o[Const.JSON_VIA_briefEn];
                            }
                            else
                            {
                                return o[Const.JSON_VIA_briefEn];
                            }
                        }));
                        viazuh = true;
                    }
                }

                if(!viazuh)
                {
                    if (row[Const.JSON_FROM_Code].ToString() == Const.ZUH)
                    {
                        std = row[Const.JSON_STD].ToString();
                    }
                    else if (row[Const.JSON_TO_Code].ToString() == Const.ZUH)
                    {
                        sta = row[Const.JSON_STA].ToString();
                    }
                }



                via = string.Join(" ", via, row[Const.JSON_TO_BriefCn]);
                viaen = string.Join(" ", viaen, row[Const.JSON_TO_BriefEn]);


                prow.from = row[Const.JSON_FROM_BriefCn].ToString();
                prow.en_from = row[Const.JSON_FROM_BriefEn].ToString();
                prow.tovia = via.Trim();
                prow.en_tovia = viaen.Trim();
                prow.flight = row[Const.JSON_FLIGHT].ToString();
                prow.airlinecode = row[Const.JSON_airlinesCode] != null ? row[Const.JSON_airlinesCode].ToString() : string.Empty;
                prow.std = std;
                prow.sta = sta;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void DeletePlan(MySql.Data.MySqlClient.MySqlConnection connection, MySql.Data.MySqlClient.MySqlTransaction tran, int dayOfWeek)
        {
            string sql = "DELETE FROM `zh-fids`.`flightplan` WHERE day ='" + dayOfWeek.ToString() + "'";
            MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(sql, connection, tran);
            comm.ExecuteNonQuery();
        }

        #endregion

        public static bool GetDynamicByPlan()
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var adapter = new data.FIDSDatasetTableAdapters.flightdynamicTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var pTable = data.FIDSAdapter.FlightPlanAdapter.GetData();
                var dyTable = adapter.GetData();
                var deleteRows = dyTable.Where((o) =>
                {
                    if (!o.manual)
                    {
                        o.Delete();
                    }
                    return true;
                }).ToArray();
                if (deleteRows.Length > 0)
                {
                    adapter.Update(deleteRows);
                }

                foreach (data.FIDSDataset.flightplanRow prow in pTable.Where(o => o.day == (int)DateTime.Now.DayOfWeek))
                {
                    try
                    {
                        var newDyRow = dyTable.NewflightdynamicRow();
                        newDyRow.date = DateTime.Now.ToString(global.Const.DATEFORMAT);
                        newDyRow.flight = prow.flight;
                        newDyRow.airlinecode = prow.airlinecode;
                        newDyRow.from = prow.from;
                        newDyRow.en_from = prow.en_from;
                        newDyRow.tovia = prow.tovia;
                        newDyRow.en_tovia = prow.en_tovia;
                        newDyRow.std = prow.std;
                        newDyRow.etd = string.Empty;
                        newDyRow.atd = string.Empty;
                        newDyRow.sta = prow.sta;
                        newDyRow.eta = string.Empty;
                        newDyRow.ata = string.Empty;
                        newDyRow.flightdynamicid = Guid.NewGuid().ToString();
                        newDyRow.lastmodifytime = DateTime.Now;
                        newDyRow.manual = false;
                        newDyRow.forceshow = 0;
                        newDyRow.departstatus = string.Empty;
                        newDyRow.en_departstatus = string.Empty;
                        newDyRow.departoutward = string.Empty;
                        newDyRow.departoutward_en = string.Empty;
                        newDyRow.arrivalstatus = string.Empty;
                        newDyRow.en_arrivalstatus = string.Empty;
                        newDyRow.arrivaloutward = string.Empty;
                        newDyRow.arrivaloutward_en = string.Empty;
                        newDyRow.counter = string.Empty;
                        newDyRow.carousel = string.Empty;
                        newDyRow.gate = string.Empty;
                        dyTable.AddflightdynamicRow(newDyRow);
                    }
                    catch
                    {
                    }
                }
                if (dyTable.Count == 0)
                {
                    tran.Rollback();
                }
                else
                {
                    adapter.Update(dyTable);
                    tran.Commit();
                    return true;
                }

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                MessageBox.Show(string.Format(Const.ERROR, ex.Message));
            }
            finally
            {
                adapter.Connection.Close();
            }
            return false;
        }

        #region airline
        public static void SyncAirlines(ServicesBinding service)
        {
            try
            {
                string outMsg, outStr;
                service.getAirlines(out outMsg, out outStr);
                UpdateAirlinesByJSON(outStr);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }

        }
        private static void UpdateAirlinesByJSON(string JSON)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var updateRows = new List<data.FIDSDataset.airlineRow>();
            var adapter = new data.FIDSDatasetTableAdapters.airlineTableAdapter();
            try
            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(JSON);
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var airlineTable = adapter.GetData();
                foreach (DataRow row in airlineTable)
                {
                    row.Delete();
                }
                adapter.Update(airlineTable);
                foreach (var row in ja)
                {
                    if (row[Const.JSON_Airline_code] != null)
                    {
                        try
                        {
                            data.FIDSDataset.airlineRow alrow;
                            var rows = airlineTable.Where(o => o.code == row[Const.JSON_Airline_code].ToString()).ToArray();
                            if (rows.Length > 0)
                            {
                                alrow = rows[0];
                                if (SetAirlineRow(alrow, row))
                                {
                                    updateRows.Add(alrow);
                                }
                            }
                            else
                            {
                                alrow = airlineTable.NewairlineRow();
                                alrow.code = row[Const.JSON_Airline_code].ToString();
                                if (SetAirlineRow(alrow, row))
                                {
                                    airlineTable.Rows.Add(alrow);
                                    updateRows.Add(alrow);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.StackTrace);

                        }
                    }
                }
                adapter.Update(updateRows.ToArray());
                tran.Commit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
        }
        private static bool SetAirlineRow(data.FIDSDataset.airlineRow alrow, Newtonsoft.Json.Linq.JToken row)
        {
            try
            {
                alrow.name = row[Const.JSON_Airline_nameCn] != null ? row[Const.JSON_Airline_nameCn].ToString() : string.Empty;
                alrow.en_name = row[Const.JSON_Airline_nameCn] != null ? row[Const.JSON_Airline_nameEn].ToString() : string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        #endregion

        #region airport
        public static void SyncAirport(ServicesBinding service)
        {
            try
            {
                string outMsg, outStr;
                service.getAirports(out outMsg, out outStr);
                UpdateAirportByJSON(outStr);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }

        }
        private static void UpdateAirportByJSON(string JSON)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var updateRows = new List<data.FIDSDataset.airportRow>();
            var adapter = new data.FIDSDatasetTableAdapters.airportTableAdapter();
            try
            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(JSON);
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var airportTable = adapter.GetData();
                foreach (DataRow row in airportTable)
                {
                    row.Delete();
                }
                adapter.Update(airportTable);
                foreach (var row in ja)
                {
                    if (row[Const.JSON_Airport_code] != null)
                    {
                        try
                        {
                            data.FIDSDataset.airportRow alrow;
                            var rows = airportTable.Where(o => o.code == row[Const.JSON_Airport_code].ToString()).ToArray();
                            if (rows.Length > 0)
                            {
                                alrow = rows[0];
                                if (SetAirportRow(alrow, row))
                                {
                                    updateRows.Add(alrow);
                                }
                            }
                            else
                            {
                                alrow = airportTable.NewairportRow();
                                alrow.code = row[Const.JSON_Airport_code].ToString();
                                if (SetAirportRow(alrow, row))
                                {
                                    airportTable.Rows.Add(alrow);
                                    updateRows.Add(alrow);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.StackTrace);

                        }
                    }
                }
                adapter.Update(updateRows.ToArray());
                tran.Commit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
        }
        private static bool SetAirportRow(data.FIDSDataset.airportRow alrow, Newtonsoft.Json.Linq.JToken row)
        {
            try
            {
                alrow.name = row[Const.JSON_Airport_nameCn] != null ? row[Const.JSON_Airport_nameCn].ToString() : string.Empty;
                alrow.nameEn = row[Const.JSON_Airport_nameEn] != null ? row[Const.JSON_Airport_nameEn].ToString() : string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        #endregion

        #region timesplit
        public static void SyncTimeSplit(ServicesBinding service)
        {
            try
            {
                string outMsg = service.getFlightDynamicSplitTime();
                UpdateTimeSplit(outMsg);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }

        }
        private static void UpdateTimeSplit(string timesplit)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var updateRows = new List<data.FIDSDataset.airportRow>();
            var adapter = new data.FIDSDatasetTableAdapters.configTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var timesplitrow = adapter.GetData().Where(o=>o.code == global.Const.TIMESPLITCONFIG).ToArray()[0];
                if (timesplitrow.value != timesplit)
                {
                    timesplitrow.value = timesplit;
                    adapter.Update(timesplitrow);
                }


                tran.Commit();

                global.Variable.TIMESPLIT = GetTimeSplit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
        }

        public static TimeSpan GetTimeSplit()
        {
            try
            {
                var timesplit = data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.TIMESPLITCONFIG).ToArray()[0].value;
                var time = DateTime.Parse(timesplit);
                return new TimeSpan(time.Hour, time.Minute, 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
                return new TimeSpan(6, 0, 0);
            }
        }
        #endregion

        public static void SyncDictionary(ServicesBinding service)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var updateRows = new List<data.FIDSDataset.dictionaryRow>();
            var adapter = new data.FIDSDatasetTableAdapters.dictionaryTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                ClearDictionary(adapter, tran);
                string outMsg, outStr;
                service.getAbnormalCause(null, out outMsg, out outStr);
                UpdateFlightStatusDictByJSON(service.getDictEntry(Const.Dictionary_FlightStatus), adapter, tran);
                UpdateAbnormalCauseDictByJSON(outStr, adapter, tran);
                tran.Commit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
            }
            finally
            {
                adapter.Connection.Close();
            }
        }

        private static void ClearDictionary(data.FIDSDatasetTableAdapters.dictionaryTableAdapter adapter, MySql.Data.MySqlClient.MySqlTransaction tran)
        {
            var sql = "TRUNCATE TABLE `zh-fids`.dictionary";
            MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(sql, adapter.Connection, tran);
            comm.ExecuteNonQuery();
        }


        private static void UpdateFlightStatusDictByJSON(string JSON, data.FIDSDatasetTableAdapters.dictionaryTableAdapter adapter, MySql.Data.MySqlClient.MySqlTransaction tran)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(JSON);
            var dictTable = adapter.GetData();
            for (var i = 0; i < ja.Count; i++)
            {
                var dicrow = dictTable.NewdictionaryRow();
                if (SetFlightStatusDictRow(dicrow, ja[i]))
                {
                    dictTable.Rows.Add(dicrow);
                }
            }

            adapter.Update(dictTable);
        }
        private static void UpdateAbnormalCauseDictByJSON(string JSON, data.FIDSDatasetTableAdapters.dictionaryTableAdapter adapter, MySql.Data.MySqlClient.MySqlTransaction tran)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(JSON);
            var dictTable = adapter.GetData();
            for (var i = 0; i < ja.Count; i++)
            {
                var dicrow = dictTable.NewdictionaryRow();
                dicrow.index = i;
                if (SetAbnormalCauseDictRow(dicrow, ja[i]))
                {
                    dictTable.Rows.Add(dicrow);
                }
            }

            adapter.Update(dictTable);
        }

        private static bool SetAbnormalCauseDictRow(data.FIDSDataset.dictionaryRow dicrow, Newtonsoft.Json.Linq.JToken row)
        {
            try
            {
                dicrow.code = row[Const.JSON_AbnormalCause_code].ToString();
                dicrow.name = row[Const.JSON_AbnormalCause_outwardCn].ToString();
                dicrow.en_name = row[Const.JSON_AbnormalCause_outwardEn] != null ? row[Const.JSON_AbnormalCause_outwardEn].ToString() : string.Empty;
                dicrow.type = Const.Dictionary_AbnormalCause;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }

        private static bool SetFlightStatusDictRow(data.FIDSDataset.dictionaryRow dicrow, Newtonsoft.Json.Linq.JToken row)
        {
            try
            {
                dicrow.code = row[Const.JSON_Dict_dictID].ToString();
                dicrow.name = row[Const.JSON_Dict_dictName] != null ? row[Const.JSON_Dict_dictName].ToString() : string.Empty;
                dicrow.en_name = row[Const.JSON_Dict_dictID] != null ? row[Const.JSON_Dict_dictID].ToString() : string.Empty;
                dicrow.type = Const.Dictionary_FlightStatus;
                dicrow.index = row[Const.JSON_Dict_sortNo] != null ? int.Parse(row[Const.JSON_Dict_sortNo].ToString()) : 0;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }

        public static ServicesBinding CreateService()
        {
            ServicesBinding service = new ServicesBinding();
            service.EosSoapHeaderValue = new UserObject();
            service.EosSoapHeaderValue.UserId = Variable.USER;
            service.EosSoapHeaderValue.Password = Variable.PASSWORD;
            service.Timeout = 60000;
            return service;
        }
        
        public static void InitIcon()
        {
            Variable.ImageDictionary.Clear();

            foreach (data.FIDSDataset.airlineRow row in data.FIDSAdapter.AirlineAdapter.GetData().Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.code))
                {
                    var iconPath = Variable.LOGOFolder + "\\" + row.code + ".png";
                    if (File.Exists(iconPath))
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(iconPath);

                        System.Drawing.Image bmp = new System.Drawing.Bitmap(img);

                        img.Dispose();

                        Variable.ImageDictionary.Add(row.code, bmp);
                    }
                }
            }
        }

        public static Image GetIcon(string key)
        {
            Image icon = null;
            if (global.Variable.ImageDictionary.ContainsKey(key))
            {
                icon = global.Variable.ImageDictionary[key];
            }
            else
            {
                var BlankImage = new Bitmap(52, 52); // 创建一个52*52的Bitmap
                Graphics g = Graphics.FromImage(BlankImage);
                g.Clear(Color.FromArgb(0, Color.FromArgb(0)));
                icon = BlankImage;
            }
            return icon;
        }

        public static void InitColor()
        {
            var adapter = new data.FIDSDatasetTableAdapters.remarkinfoviewTableAdapter();
            Variable.ColorTable = adapter.GetData();
        }

        public static Color GetColor(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return Color.White;
            }
            var colorrow = Variable.ColorTable.Where((o) => {
                return text == o.code;
            }).ToList();
            if (colorrow.Count > 0)
            {
                return Color.FromArgb(colorrow.First().color);
            }
            else
            {
                return Color.White;
            }
        }

        public static void InitLogo()
        {
            Variable.ImageLogoDictionary.Clear();

            foreach (data.FIDSDataset.airlineRow row in data.FIDSAdapter.AirlineAdapter.GetData().Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.code))
                {
                    var logoPath = Variable.LOGOFolder + "\\" + row.code + ".jpg";
                    if (File.Exists(logoPath))
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(logoPath);

                        System.Drawing.Image bmp = new System.Drawing.Bitmap(img);

                        img.Dispose();
                        Variable.ImageLogoDictionary.Add(row.code, bmp);
                    }
                }
            }
        }
        public static Image GetLogo(string key)
        {
            Image logo = null;
            if (global.Variable.ImageLogoDictionary.ContainsKey(key))
            {
                logo = global.Variable.ImageLogoDictionary[key];
            }
            else
            {
                var BlankImage = new Bitmap(52, 52); // 创建一个52*52的Bitmap
                Graphics g = Graphics.FromImage(BlankImage);
                g.Clear(Color.FromArgb(0, Color.FromArgb(0)));
                logo = BlankImage;
            }
            return logo;
        }

    }
}
