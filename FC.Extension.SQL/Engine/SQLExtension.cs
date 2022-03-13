using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using FC.Extension.SQL.MySQL;
using FC.Extension.SQL.PostgreSQL;
using FC.Extension.SQL.SQLServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FC.Extension.SQL.Mongo;

namespace FC.Extension.SQL.Engine
{
    /// <summary>
    /// A Class that provies basic property in order to execute our query
    /// </summary>
    public static class SQLExtension
    {
        /// <summary>
        /// SQL Conifguation
        /// </summary>
        public static SQLConfig SQLConfig { get; set;  }
        
        /// <summary>
        /// Gets the compiler base object for executing the model object
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <returns>returns the connection object to execute model in the database</returns>
        public static IBaseAccess<TModel> GetCompiler<TModel>() where TModel : class
        {
            IBaseAccess<TModel> baseAccess = null;
            switch (SQLConfig.Compiler)
            {
                case SQLCompiler.PostgreSQL:
                    baseAccess = new PostgreSQLDataAccess<TModel>(SQLConfig.ConnectionString, SQLConfig.Trace);
                    break;
                case SQLCompiler.SQLServer:
                    baseAccess = new SQLServerDataAccess<TModel>(SQLConfig.ConnectionString, SQLConfig.Trace);
                    break;
                case SQLCompiler.SQLite:
                    baseAccess = new SQLiteDataAccess<TModel>(SQLConfig.ConnectionString, SQLConfig.Trace);
                    break;
                case SQLCompiler.MySQL:
                    baseAccess = new MySQLDataAccess<TModel>(SQLConfig.ConnectionString, SQLConfig.Trace);
                    break;
                default:
                    break;
            }
            return baseAccess;
        }
        
        /// <summary>
        /// Gets the compiler base object for executing the model object, specific to NoSQL.
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <returns>returns the connection object to execute model in the database</returns>
        public static INoSQLBaseAccess<TModel> GetNoSQLCompiler<TModel>() where TModel : class
        {
            INoSQLBaseAccess<TModel> baseAccess = null;
            switch (SQLConfig.Compiler)
            {
                case SQLCompiler.MongoDB:
                    baseAccess = new MongoDataAccess<TModel>(sqlConfig: SQLConfig);
                    break;
                default:
                    break;
            }
            return baseAccess;
        }
    }
}
