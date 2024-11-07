using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayDayUI.Model
{
    [SugarTable("Log")]
    public class LogModel
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int ID { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogDate { get; set; }
    }
}
