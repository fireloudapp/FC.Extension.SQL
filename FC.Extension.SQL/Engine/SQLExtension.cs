using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using FC.Extension.SQL.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Engine
{
    public static class SQLExtension
    {
        public static SQLConfig SQLConfig { get; set;  }
        
        public static IBaseAccess<TModel> GetCompiler<TModel>() where TModel : class
        {
            IBaseAccess<TModel> baseAccess = null;
            switch (SQLConfig.Compiler)
            {
                case SQLCompiler.PostgreSQL:
                    baseAccess = new PostgreSQLDataAccess<TModel>(SQLConfig.ConnectionString, SQLConfig.Trace);
                    break;
                default:
                    break;
            }
            return baseAccess;
        }
    }
}
