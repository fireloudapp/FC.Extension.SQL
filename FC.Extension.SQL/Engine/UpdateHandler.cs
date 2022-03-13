using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FC.Extension.SQL.Engine
{    
    public static class UpdateHandler
    {
        public static async Task<T> Update<T>
            (this T model) where T : class
        {
            T? entity = null;
            if (SQLExtension.SQLConfig == null) return model;

            if (SQLExtension.SQLConfig.DBType == DBType.SQL)
            {
                IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
                entity = await baseAccess.UpdateAsync(model);
            }
            return entity;
        }
        
        public static async Task<T> Update<T>
            (this T model, Expression<Func<T, bool>> filter ) where T : class
        {
            T? entity = null;
            if (SQLExtension.SQLConfig == null) return model;

            if (SQLExtension.SQLConfig.DBType == DBType.SQL)
            {
                IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
                entity = await baseAccess.UpdateAsync(model);
            }
            else
            {
                INoSQLBaseAccess<T> baseAccess = SQLExtension.GetNoSQLCompiler<T>();
                entity = await baseAccess.UpdateAsync(filter, model);
            }

            return entity;
        }

        
    }
}
