using DayDayWinForm.Tools;
using Microsoft.Owin.Hosting;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace DayDayWinForm.APIService
{
    internal class Service
    {
        private static IDisposable _disposable;

        private Service()
        {

        }

        public static readonly Service sercives = new Service();

        /// <summary>
        /// 启动
        /// </summary>
        public bool Start()
        {
            if (_disposable != null)
            {
                return true;
            }

            try
            {
                string baseAddress = $"http://{AppConfig.ServiceIP}:{AppConfig.ServicePort}/";
                
                _disposable = WebApp.Start<Startup>(url: baseAddress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (_disposable != null)
            {
                _disposable.Dispose();
                _disposable = null;
            }
        }

        public APIStatus Status { get { return _disposable == null ? APIStatus.Close : APIStatus.Open; } }

        public enum APIStatus
        {
            Open,
            Close
        }

    }
}
