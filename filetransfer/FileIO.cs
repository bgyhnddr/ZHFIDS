using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.ComponentModel;

namespace filetransfer
{
    public partial class FileIO
    {
        public delegate void FinishHandle();
        private static Thread ListenThread;
        private static Socket ListenSocket;

        public static void CreateLogoADFolder()
        {
            if (!Directory.Exists(global.Variable.LOGOFolder))
            {
                Directory.CreateDirectory(global.Variable.LOGOFolder);
            }
            if (!Directory.Exists(global.Variable.ADFolder))
            {
                Directory.CreateDirectory(global.Variable.ADFolder);
            }
        }

        public static void OpenLogoFolder()
        {
            CreateLogoADFolder();
            System.Diagnostics.Process.Start("explorer.exe", global.Variable.LOGOFolder);
        }

        public static void OpenADFolder()
        {
            CreateLogoADFolder();
            System.Diagnostics.Process.Start("explorer.exe", global.Variable.ADFolder);
        }

        public static void StartFileListen(Form form = null, FinishHandle finishCallback = null)
        {
            if (ListenSocket != null)
            {
                if (ListenSocket.IsBound)
                {
                    ListenSocket.Close();
                }
            }
            ListenThread = new Thread(new ParameterizedThreadStart((objj) =>
            {
                #region linsten Thread
                ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    CreateLogoADFolder();
                    //设定接收超时
                    ListenSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
                    //设定发送超时
                    ListenSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 0);
                    var ip = new IPEndPoint(global.Variable.IP, global.Variable.Port);
                    ListenSocket.Bind(ip);
                    ListenSocket.Listen(0);
                    //开启线程 监控连接

                    while (true)
                    {
                        var newSocket = ListenSocket.Accept();

                        var parStart = new ParameterizedThreadStart((o) =>
                        {
                            try
                            {
                                #region receive Thread
                                var par = (List<Object>)o;
                                var oSocket = (Socket)par[0];
                                var thisForm = (Form)par[1];
                                var finish = (FinishHandle)par[2];
                                var time = DateTime.Now;

                                var typeBytes = new byte[1];
                                oSocket.Receive(typeBytes);
                                oSocket.Send(new byte[1] { (byte)1 });

                                if (typeBytes[0] < (byte)2)
                                {


                                    MySql.Data.MySqlClient.MySqlTransaction tran = null;
                                    var adapter = new data.FIDSDatasetTableAdapters.ipcstatusTableAdapter();
                                    try
                                    {
                                        adapter.Connection.Open();
                                        tran = adapter.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable);

                                        var ipcstatus = adapter.GetData().Where(ipcs => ipcs.ip == global.Variable.IP.ToString()).ToArray();

                                        if (ipcstatus.Length > 0)
                                        {
                                            if (typeBytes[0] == (byte)1)
                                            {
                                                try
                                                {
                                                    SaveFile(oSocket, global.Variable.LOGOFolder);
                                                    ipcstatus[0].logodate = DateTime.Now.ToString(global.Const.DATETIMEFORMAT);
                                                    DeleteOldFile(global.Variable.LOGOFolder, time);
                                                }
                                                catch
                                                {
                                                    ipcstatus[0].logodate = global.Const.UNNORMAL;
                                                }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    SaveFile(oSocket, global.Variable.ADFolder);
                                                    ipcstatus[0].addate = DateTime.Now.ToString(global.Const.DATETIMEFORMAT);
                                                    DeleteOldFile(global.Variable.ADFolder, time);
                                                }
                                                catch
                                                {
                                                    ipcstatus[0].addate = global.Const.UNNORMAL;
                                                }
                                            }
                                            oSocket.Close();
                                            if (finish != null && thisForm.IsDisposed)
                                            {
                                                thisForm.Invoke(finish);
                                            }
                                            adapter.Update(ipcstatus[0]);
                                        }
                                        tran.Commit();
                                    }
                                    catch (Exception ex)
                                    {
                                        oSocket.Close();
                                        if (tran != null)
                                        {
                                            tran.Rollback();
                                        }
                                        MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
                                    }
                                    finally
                                    {
                                        adapter.Connection.Close();
                                    }
                                #endregion
                                }
                                else
                                {

                                }
                            }
                            catch
                            {
                            }
                        });
                        var acceptThread = new Thread(parStart);
                        List<object> obj = new List<object>();
                        obj.Add(newSocket);
                        obj.Add(((List<object>)objj)[0]);
                        obj.Add(((List<object>)objj)[1]);
                        acceptThread.IsBackground = true;
                        acceptThread.Start(obj);
                    }
                }
                catch (SocketException ex)
                {
                    Debug.Print(ex.Message);
                }
                catch (Exception ex)
                {
                    ListenSocket.Close();
                    MessageBox.Show(string.Format(global.Const.FILETRANSFERERROR, ex.Message));
                }
                #endregion
            }));
            ListenThread.IsBackground = true;
            List<object> objout = new List<object>();
            objout.Add(form);
            objout.Add(finishCallback);
            ListenThread.Start(objout);
        }

        private void HandleRec(byte action)
        {
            switch(action)
            {
                case (byte)2:
                    try
                    {
                        //启动本地程序并执行命令
                        Process.Start("shutdown.exe", " -r -t 0");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case (byte)3:
                    try
                    {
                        //启动本地程序并执行命令
                        Process.Start("Shutdown.exe", " -s -t 0");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }

        private static void DeleteOldFile(string path,DateTime time)
        {
            DirectoryInfo mydir = new DirectoryInfo(path);
            foreach(FileInfo file in mydir.GetFiles())
            {
                if (file.LastWriteTime < time)
                {
                    file.Delete();
                }
            }
        }

        private static void SaveFile(Socket socket,string path)
        {
            while (true)
            {
                //获取文件大小
                var fileSizeByte = new byte[4];
                socket.Receive(fileSizeByte);
                var fizeSize = BitConverter.ToInt32(fileSizeByte, 0);
                //文件大小大于0才进行文件接收，否则表示文件发送完毕
                if (fizeSize > 0)
                {
                    //发送1表示接收文件大小成功
                    socket.Send(new byte[1] { (byte)1 });

                    //接收文件名字
                    var fileNameByte = new byte[256];
                    socket.Receive(fileNameByte);
                    var fileName = Encoding.UTF8.GetString(fileNameByte).Replace("\0", string.Empty);
                    //回复1表示成功接收
                    socket.Send(new byte[1] { (byte)1 });

                    //接收文件本体并保存
                    var imageFileByte = new byte[fizeSize];

                    int flag = 0;
                    while (flag < imageFileByte.Length)
                    {
                        flag += socket.Receive(imageFileByte, flag, imageFileByte.Length - flag, SocketFlags.None);
                    }
                    Debug.Print(flag.ToString() + " " + imageFileByte.Length);
                    File.WriteAllBytes(path + "\\" + fileName, imageFileByte);
                    //发送1表示该文件接收完毕
                    socket.Send(new byte[1] { (byte)1 });
                }
                else
                {
                    break;
                }
            }
        }

        private static Socket ConnectIPC(string ipcIP)
        {
            var ipcRows = data.FIDSAdapter.IPCStatusAdapter.GetData().Where(o => o.ip == ipcIP).ToArray();
            if (ipcRows.Length > 0)
            {
                var socket = new Socket(global.Variable.IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout,0);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout,0);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, 1);
                socket.Connect(new IPEndPoint(IPAddress.Parse(ipcRows[0].ip), ipcRows[0].port));
                return socket;
            }
            else
            { return null; }
        }

        public static void SendLogoFileToIPC(string ipcIP)
        {
            var progressForm = new global.ProgressBar(global.Const.SYNCDATASOURCE);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                var obj = (System.ComponentModel.BackgroundWorker)sender;
                try
                {
                    obj.ReportProgress(0, "正在连接" + ipcIP);
                    var socket = ConnectIPC(ipcIP);
                    if (socket != null)
                    {
                        DirectoryInfo mydir = new DirectoryInfo(global.Variable.LOGOFolder);
                        var files = mydir.GetFiles().Where(o => o.Extension.ToLower() == ".png" || o.Extension.ToLower() == ".jpg").ToArray();
                        obj.ReportProgress(0, "准备发送logo文件到" + ipcIP);
                        socket.Send(new byte[1] { (byte)1 });
                        var receiveByte = new byte[1];
                        socket.Receive(receiveByte);
                        for (var i = 0; i < files.Length; i++)
                        {
                            obj.ReportProgress((int)((float)(i + 1) / (float)(files.Length) * 100F), "正在发送" + files[i].Name + "到" + ipcIP);
                            Thread.Sleep(10);
                            SendFile(socket, files[i]);
                        }
                        socket.Send(BitConverter.GetBytes(0));
                    }

                    obj.ReportProgress(100, "完成");

                    Thread.Sleep(500);
                }
                catch(Exception ex)
                {
                    obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                }


            });
            progressForm.Show();
        }

        public static void ControlIPC(string ipcIP, byte action)
        {
            var message = action == (byte)2 ? global.Const.REBOOT : global.Const.SHUTDOWN;

            var progressForm = new global.ProgressBar(message);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                var obj = (System.ComponentModel.BackgroundWorker)sender;
                try
                {
                    obj.ReportProgress(0, "正在连接" + ipcIP);
                    ControlIP(ipcIP, action);

                    obj.ReportProgress(100, "完成");

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                }


            });
            progressForm.Show();
        }

        public static void ControlIP(string ip,byte action)
        {
            var socket = ConnectIPC(ip);
            if (socket != null)
            {
                socket.Send(new byte[1] { action });
            }
        }


        public static void SendADFileToIPC(string ipcIP)
        {
            var progressForm = new global.ProgressBar(global.Const.SYNCDATASOURCE);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                var obj = (System.ComponentModel.BackgroundWorker)sender;
                try
                {
                    obj.ReportProgress(0, "正在连接" + ipcIP);
                    var socket = ConnectIPC(ipcIP);
                    if (socket != null)
                    {
                        DirectoryInfo mydir = new DirectoryInfo(global.Variable.ADFolder);
                        var files = mydir.GetFiles().Where(o => o.Extension.ToLower() == ".jpg").ToArray();
                        obj.ReportProgress(0, "准备发送广告文件到" + ipcIP);
                        socket.Send(new byte[1] { (byte)0 });
                        var receiveByte = new byte[1];
                        socket.Receive(receiveByte);
                        if (receiveByte[0] == (byte)1)
                        {
                            for (var i = 0; i < files.Length; i++)
                            {
                                obj.ReportProgress((int)((float)(i + 1) / (float)(files.Length) * 100F), "正在发送" + files[i].Name + "到" + ipcIP);
                                Thread.Sleep(10);
                                SendFile(socket, files[i]);
                            }
                        }
                        socket.Send(BitConverter.GetBytes(0));
                    }

                    obj.ReportProgress(100, "完成");

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                    Thread.Sleep(3000);
                }
            });
            progressForm.Show();
        }

        private static void SendFile(Socket socket, FileInfo file)
        {
            var imageByte = File.ReadAllBytes(file.FullName);
            var fileSizeByte = BitConverter.GetBytes((int)imageByte.Length);

            socket.Send(fileSizeByte);

            var answerByte = new byte[1];
            socket.Receive(answerByte);
            if (answerByte[0] == (byte)1)
            {
                var fileNameByte = Encoding.UTF8.GetBytes(file.Name);
                socket.Send(fileNameByte);
                socket.Receive(answerByte);
                if (answerByte[0] == (byte)1)
                {
                    socket.Send(imageByte);
                    socket.Receive(answerByte);
                }
            }
        }
    }
}
