using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DayDayUI.Tools
{
    internal static class ExtendMethods
    {
        internal static List<string> GetColumns(this DataTable dataTable)
        {
            List<string> strings = new List<string>();

            if (dataTable == null)
            {
                return strings;
            }
            
            foreach (DataColumn item in dataTable.Columns)
            {
                strings.Add(item.ColumnName);
            }
            
            return strings;
        }
    }
}
