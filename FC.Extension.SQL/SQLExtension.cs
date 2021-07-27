using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using FC.Extension.SQL.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FC.Extension.SQL
{
    public static class SQLExtension
    {
        public static SQLConfig SQLConfig { get; set;  }

        public static async Task<T> Save<T>(this T model) where T : class
        {
            T? entity = null; 
            if (SQLConfig == null) return model;

            IBaseAccess<T> baseAccess = GetCompiler<T>();
            entity = await baseAccess.CreateAsync(model);

            return entity;
        }

        public static async Task<T> Update<T>(this T model) where T : class
        {
            T? entity = null;
            if (SQLConfig == null) return model;

            IBaseAccess<T> baseAccess = GetCompiler<T>();
            entity = await baseAccess.UpdateAsync(model);

            return entity;
        }

        public static async Task<int> Delete<T>(this T model, object id) where T : class
        {
            int noOfRecords = 0;
            if (SQLConfig == null) return 0;

            IBaseAccess<T> baseAccess = GetCompiler<T>();
            noOfRecords = await baseAccess.DeleteAsync(id);

            return noOfRecords;
        }

        public static async Task<T> Get<T>(this T model, object id) where T : class
        {
            T? entity = null;
            if (SQLConfig == null) return model;

            IBaseAccess<T> baseAccess = GetCompiler<T>();
            entity = await baseAccess.GetByIdAsync(id);

            return entity;
        }

        public static async Task<IEnumerable<T>> GetAll<T>(this T model) where T : class
        {
            IEnumerable<T> modelList = null;
            if (SQLConfig == null) return null;

            IBaseAccess<T> baseAccess = GetCompiler<T>();
            modelList = await baseAccess.GetAllAsync();

            return modelList;
        }

        private static IBaseAccess<TModel> GetCompiler<TModel>() where TModel : class
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
