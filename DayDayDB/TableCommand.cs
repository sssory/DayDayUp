using DataBase.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{

    /// <summary>
    /// 分表分库语句类
    /// </summary>
    public class TableCommand
    {
        //分库
        public static string dayda_yyyyy = $"CREATE DATABASE IF NOT EXISTS daydaydb{DateTime.Now.ToString("yyyy")};";

        /// <summary>
        /// 分表logs_yyyyMMdd
        /// </summary>
        /// <returns></returns>
        public static bool logs_create()
        {
            string cmd = dayda_yyyyy + $"CREATE TABLE IF NOT EXISTS `daydaydb{DateTime.Now.ToString("yyyy")}`.`logs{DateTime.Now.ToString("yyyyMMdd")}` (`Id` int(10) NOT NULL AUTO_INCREMENT,`LogMessage` varchar(255) NOT NULL,`LogDate` datetime NOT NULL,`UserId` int(10) unsigned NOT NULL DEFAULT '0',PRIMARY KEY (`Id`) USING BTREE) ENGINE=InnoDB AUTO_INCREMENT=492 DEFAULT CHARSET=utf8;";
            int res = Sugar.MySql.Ado.ExecuteCommand(cmd);
            return res > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static bool logs_insert(logs log)
        {
            logs_create();
            //插入 logs
            string cmd = $"INSERT INTO `daydaydb{DateTime.Now.ToString("yyyy")}`.`logs{DateTime.Now.ToString("yyyyMMdd")}`(LogMessage,LogDate,UserId) VALUES ('{log.LogMessage}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',{log.UserId});";
            int res = Sugar.MySql.Ado.ExecuteCommand(cmd);
            return res > 0;
        }
    }
}
