using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.SQL.Helper
{
    public class SQLConfig
    {
        public string ConnectionString { get; set;  }
        public BaseTrace Trace { get; set; }    
        public string DataBaseName { get; set; }
        /// <summary>
        /// Normally called as Collection in MongoDB, similar to Tables in SQL World.
        /// </summary>
        public string CollectionName { get; set; }
        public SQLCompiler Compiler { get; set; }

        /// <summary>
        /// Default DB type is Releational DB.
        /// </summary>
        public DBType DBType { get; set; } = DBType.SQL;
    }

    public enum DBType
    {
        SQL,
        NoSQL
    }
    public enum SQLCompiler
    {
        SQLServer,
        PostgreSQL,
        MySQL,
        SQLite,
        MongoDB
    }
}
