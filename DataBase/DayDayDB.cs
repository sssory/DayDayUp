using DataBase.MySql;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public static class DayDayDB
    {
        static DayDayDB()
        {

        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init(string ConnectionString)
        {
            Sugar.Init(ConnectionString);
        }

        public static List<T> GetList<T>(string where = "") where T : class, new()
        {
            return Sugar.MySql.Queryable<T>().Where(where).ToList();
        }
        public static List<T> GetQuery<T>(string sql) where T : class
        {
            return Sugar.MySql.Ado.SqlQuery<T>(sql);
        }
        public static object GetObject(string cmd)
        {
            return Sugar.MySql.Ado.GetScalar(cmd);
        }
        public static T Insert<T>(T ent) where T : class, new()
        {
            return (T)Sugar.MySql.Insertable<T>(ent).ExecuteReturnEntity();
        }
        public static List<T> Insert<T>(List<T> ent) where T : class, new()
        {
            return (List<T>)Sugar.MySql.Insertable<List<T>>(ent).ExecuteReturnEntity();
        }
        public static int Update<T>(T ent) where T : class, new()
        {
            return Sugar.MySql.Updateable<T>(ent).ExecuteCommand();
        }
        public static int Update<T>(List<T> ent) where T : class, new()
        {
            return Sugar.MySql.Updateable<T>(ent).ExecuteCommand();
        }
        public static int Delete<T>(T ent) where T : class, new()
        {
            return Sugar.MySql.Deleteable<T>(ent).ExecuteCommand();
        }
        public static int Delete<T>(List<T> ent) where T : class, new()
        {
            return Sugar.MySql.Deleteable<T>(ent).ExecuteCommand();
        }
        public static int Execute(string cmd)
        {
            return Sugar.MySql.Ado.ExecuteCommand(cmd);
        }

    }
}
