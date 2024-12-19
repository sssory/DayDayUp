using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public static class SguarBll
    {
        public static List<T> GetList<T>(string where="")
        {
            return Sugar.MySql.Queryable<T>().Where(where).ToList();
        }
    }
}
