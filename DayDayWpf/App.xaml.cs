using DataBase;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace DayDayWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IConfiguration Configuration { get; set; }
        public string DBName { get; set; }
        public App()
        {
            //创建一个配置构建器
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // 设置当前工作目录
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);  // 加载 appsettings.json

            Configuration = builder.Build();  // 构建配置对象
            DayDayDB.Init(Configuration["ConnectionStrings:MySqlConnectionString"]);
        }
    }

}
