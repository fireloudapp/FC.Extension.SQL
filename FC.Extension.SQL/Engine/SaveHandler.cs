﻿using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Engine
{
    /// <summary>
    /// Class that handles Save operation
    /// </summary>
   public static class SaveHandler 
   {
        /// <summary>
        /// Saves the object
        /// </summary>
        /// <typeparam name="T">Entity/Model Type</typeparam>
        /// <param name="model">Entity model object</param>
        /// <returns>returns the model with saved data</returns>
        public static async Task<T> Save<T>(this T model) where T : class
        {
            T? entity = null;
            if (SQLExtension.SQLConfig == null) return model;

            IBaseAccess<T> baseAccess = SQLExtension.GetCompiler<T>();
            entity = await baseAccess.CreateAsync(model);

            return entity;
        }
   }
}
