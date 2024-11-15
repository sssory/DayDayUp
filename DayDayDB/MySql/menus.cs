using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace DayDayDB.MySql
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("menus")]
    public partial class menus
    {
        public menus()
        {

            this.Sort = Convert.ToInt32("0");
            this.ParentId = Convert.ToInt32("0");

        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Code { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int Sort { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int ParentId { get; set; }

        /// <summary>
        /// Desc:control选项卡form弹窗
        /// Default:0
        /// Nullable:False
        /// </summary>        
        public string ShowType { get; set; }

        /// <summary>
        /// Desc:是否开机自启动
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int AutoStart { get; set; }

    }
}
