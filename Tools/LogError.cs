using System;
using System.IO;
using System.Threading.Tasks;

namespace Common
{
    public class LogError
    {

        private static readonly object fileLock = new object();
        public static void Write(string msg, string folder = "")
        {
            Task.Run(() =>
            {
                try
                {
                    string logPath = AppDomain.CurrentDomain.BaseDirectory;
                    logPath = Path.Combine(logPath, string.IsNullOrEmpty(folder) ? "ErrorLog" : folder);

                    if (logPath == null || logPath == "") return;

                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }

                    if (!logPath.EndsWith(@"\"))
                    {
                        logPath += @"\";
                    }

                    logPath += DateTime.Today.ToString("yyyy-MM-dd") + "-log.txt";
                    string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    lock (fileLock)//锁 防止多线程写入时发送混乱
                    {
                    startlog:
                        if (!File.Exists(logPath))
                        {
                            using (FileStream stream = File.Create(logPath, 1024, FileOptions.WriteThrough))
                            {
                                stream.Close();
                            }
                        }

                        FileInfo fileInfo = new FileInfo(logPath);

                        if (fileInfo.Exists)
                        {
                            long max = 1024 * 1024 * 50;
                            if (fileInfo.Length > max)//超过100 mb
                            {
                                fileInfo.Delete();
                                goto startlog;
                            }
                        }

                        //fileInfo.Length
                        fileInfo.IsReadOnly = false;



                        using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.GetEncoding("utf-8")))
                        {
                            //输出日期新行
                            if (msg != null && msg != "")
                                sw.Write(dt + "\r\n" + msg + "\r\n\r\n");
                            sw.Close();
                        }
                    }

                }
                catch { }
            });
        }

        public static void Write(Exception ex)
        {
            string msg = "";
            if (ex != null)
            {
                msg = ex.Message + "\r\n" + ex.Source + "\r\n" + ex.StackTrace;
            }
            Write(msg);
        }
    }
}
