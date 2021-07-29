using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Engine
{    
    public static class UpdateHandler
    {
        public static async Task<T> Update<T>(this T model) where T : class
        {
            T? entity = null;
            if (SQLExtension.SQLConfig == null) return model;

            IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
            entity = await baseAccess.UpdateAsync(model);

            return entity;
        }
    }
}
