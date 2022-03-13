using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Engine
{
    
    /// <summary>
    /// Class that handles Delete operation
    /// </summary>
    public static class DeleteHandler
    {
        /// <summary>
        /// Delete the object
        /// </summary>
        /// <typeparam name="T">Entity/Model Type</typeparam>
        /// <param name="model">Entity model object</param>
        /// <param name="id">An Unique id that will be deleted</param>
        /// <returns>returns no of records that has been deleted</returns>
        public static async Task<int> Delete<T>(this T model, object id) where T : class
        {
            int noOfRecords = 0;
            if (SQLExtension.SQLConfig == null) return 0;
            IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
            noOfRecords = await baseAccess.DeleteAsync(id);

            return noOfRecords;
        }

        public static async Task<string> Delete<T>
            (this T model, Expression<Func<T, bool>> filter, string id) where T : class
        {
            INoSQLBaseAccess<T> baseAccess = SQLExtension.GetNoSQLCompiler<T>();
            string jsonResult = await baseAccess.DeleteAsync(filter, id);

            return jsonResult;
        }


    }
}
