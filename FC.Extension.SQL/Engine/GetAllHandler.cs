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
    /// A Class that gets all the data from the given model.
    /// </summary>
    public static class GetAllHandler
    {
        /// <summary>
        /// A Get method that returns all the data from the given model. Use this for small table which is lesser then 1K Record.
        /// </summary>
        /// <typeparam name="T">Entity/Model Type</typeparam>
        /// <param name="model">Entity model object</param>
        /// <returns>returns all the model.</returns>
        public static async Task<IEnumerable<T>> GetAll<T>(this T model) where T : class
        {
            IEnumerable<T> modelList = null;
            if (SQLExtension.SQLConfig == null) return null;
            Console.WriteLine($"DB Type: {SQLExtension.SQLConfig.DBType}");
            if (SQLExtension.SQLConfig.DBType == DBType.SQL)
            {
                IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
                modelList = await baseAccess.GetAllAsync();
            }
            else if(SQLExtension.SQLConfig.DBType == DBType.NoSQL)
            {
                INoSQLBaseAccess<T> baseAccess = SQLExtension.GetNoSQLCompiler<T>();
                modelList = await baseAccess.GetAllAsync();
            }

            return modelList;
        }
        
        
    }
}
