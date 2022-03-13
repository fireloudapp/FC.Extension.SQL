﻿using FC.Extension.SQL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FC.Extension.SQL.Helper;

namespace FC.Extension.SQL.Engine
{
    /// <summary>
    /// A Class that returns the number of records in the Database.
    /// </summary>
    public static class GetCountHander
    {
        /// <summary>
        /// A Get method that returns the number of records in the Database.
        /// </summary>
        /// <typeparam name="T">Entity/Model Type</typeparam>
        /// <param name="model">Entity model object</param>
        /// <returns>returns no of records in the table..</returns>
        public static async Task<long> GetCount<T>(this T model) where T : class
        {
            long count = 0;
            if (SQLExtension.SQLConfig == null) return 0;

            if (SQLExtension.SQLConfig.DBType == DBType.SQL)
            {
                IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
                count = await baseAccess.GetRecordCountAsync();
            }
            else if (SQLExtension.SQLConfig.DBType == DBType.NoSQL)
            {
                INoSQLBaseAccess<T> baseAccess = SQLExtension.GetNoSQLCompiler<T>();
                count = await baseAccess.GetRecordCountAsync();
            }
            

            return count;
        }
    }
}
