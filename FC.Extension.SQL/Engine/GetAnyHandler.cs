using FC.Extension.SQL.Interface;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Engine
{
    /// <summary>
    /// A Class that handles and executes any query and retrieves data
    /// </summary>
    public static class GetAnyHandler
    {
        /// <summary>
        /// A Get method that returns data by a given query
        /// Ref: 
        /// </summary>
        /// <typeparam name="T">Entity/Model Type</typeparam>
        /// <param name="model">Entity model object</param>
        /// <param name="query">A query generated through SQLKata</param>
        /// <returns>returns the model based on the query.</returns>
        public static async Task<IEnumerable<T>> GetAny<T>(this T model, Query query) where T : class
        {
            IEnumerable<T> modelList = null;
            if (SQLExtension.SQLConfig == null) return null;

            IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
            modelList = await baseAccess.ExecuteQuery(query);

            return modelList;
        }
    }
}
