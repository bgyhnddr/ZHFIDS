using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UPDATE
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRuned;
            Console.WriteLine("关闭航显系统");
            Thread.Sleep(3000);
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "OnlyRunOneInstance", out isRuned);
            if (isRuned)
            {
                try
                {
                    Console.WriteLine("准备更新程序");
                    Thread.Sleep(1000);
                    Console.WriteLine("3");
                    Thread.Sleep(1000);
                    Console.WriteLine("2");
                    Thread.Sleep(1000);
                    Console.WriteLine("1");
                    Thread.Sleep(1000);

                    var updateFilePath = Environment.CurrentDirectory + "\\update";
                    if (Directory.Exists(updateFilePath))
                    {
                        DirectoryInfo mydir = new DirectoryInfo(updateFilePath);
                        var files = mydir.GetFiles();
                        files = mydir.GetFiles();
                        for (var i = 0; i < files.Length; i++)
                        {
                            Console.WriteLine("更新" + files[i].Name);
                            files[i].CopyTo(Environment.CurrentDirectory + "\\" + files[i].Name, true);
                        }

                        Directory.Delete(updateFilePath, true);

                        Console.WriteLine("更新完毕，启动航显系统");
                        Process.Start(Environment.CurrentDirectory + "\\ZHFIDS.exe");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("更新失败，启动航显系统");
                    Process.Start(Environment.CurrentDirectory + "\\ZHFIDS.exe");
                }
            }
        }
    }
}
