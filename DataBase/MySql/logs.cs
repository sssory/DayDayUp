using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.MySql
{
    [SugarTable("logs")]
    public class logs
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int ID { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogDate { get; set; }
        public int UserId { get; set; }
    }
}
