using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.SQL.Helper
{
    public class SQLConfig
    {
        public string ConnectionString { get; set;  }
        public BaseTrace Trace { get; set; }    
        public SQLCompiler Compiler { get; set; }
    }

    public enum SQLCompiler
    {
        SQLServer,
        PostgreSQL,
        MySQL,
        SQLite
    }
}
