using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.SQL.Helper
{
    /// <summary>
    /// The Property used to conifgure SQL Execution commends.
    /// </summary>
    public class SQLExecutionConfig
    {
        public string ConnectionString { get; set; }
        public SQLCompiler Compiler { get; set; }
        public BaseTrace Trace { get; set; }
    }

    /// <summary>
    /// SQL Compiler used to choose the server
    /// </summary>
    public enum SQLCompiler
    {        
        SQLServer,
        PostgreSQL,
        MySQL,
        SQLite
    }
}
