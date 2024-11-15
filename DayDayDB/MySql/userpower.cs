using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace DayDayDB.MySql
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("userpower")]
    public partial class userpower
    {
           public userpower(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int UserId {get;set;}

           /// <summary>
           /// Desc:0菜单
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int PowerType {get;set;}

    }
}
