using RepoDb.Interfaces;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.SQL.Helper
{
    /// <summary>
    /// Trace class which captures traces in console, which can be extended to any trace implementation.
    /// </summary>
    public class BaseTrace : ITrace
    {
        #region After Query Execution
        public void AfterAverage(TraceLog log)
        {

        }

        public void AfterAverageAll(TraceLog log)
        {

        }

        public virtual void AfterBatchQuery(TraceLog log)
        {

        }

        public void AfterCount(TraceLog log)
        {

        }

        public void AfterCountAll(TraceLog log)
        {

        }

        public void AfterDelete(TraceLog log)
        {

        }

        public void AfterDeleteAll(TraceLog log)
        {

        }

        public void AfterExecuteNonQuery(TraceLog log)
        {

        }

        public void AfterExecuteQuery(TraceLog log)
        {

        }

        public void AfterExecuteReader(TraceLog log)
        {

        }

        public void AfterExecuteScalar(TraceLog log)
        {

        }

        public void AfterExists(TraceLog log)
        {

        }

        public void AfterInsert(TraceLog log)
        {

        }

        public void AfterInsertAll(TraceLog log)
        {

        }

        public void AfterMax(TraceLog log)
        {

        }

        public void AfterMaxAll(TraceLog log)
        {

        }

        public void AfterMerge(TraceLog log)
        {

        }

        public void AfterMergeAll(TraceLog log)
        {

        }

        public void AfterMin(TraceLog log)
        {

        }

        public void AfterMinAll(TraceLog log)
        {

        }

        public void AfterQuery(TraceLog log)
        {

        }

        public void AfterQueryAll(TraceLog log)
        {

        }

        public void AfterQueryMultiple(TraceLog log)
        {

        }

        public void AfterSum(TraceLog log)
        {

        }

        public void AfterSumAll(TraceLog log)
        {

        }

        public void AfterTruncate(TraceLog log)
        {

        }

        public void AfterUpdate(TraceLog log)
        {
            Console.WriteLine($"AfterUpdate: {log.Statement}, TotalTime: {log.ExecutionTime.TotalSeconds} second(s)");
        }

        public void AfterUpdateAll(TraceLog log)
        {

        }

        #endregion

        #region Before Execution

        public void BeforeAverage(CancellableTraceLog log)
        {

        }

        public void BeforeAverageAll(CancellableTraceLog log)
        {

        }

        public virtual void BeforeBatchQuery(CancellableTraceLog log)
        {
            Console.WriteLine($"BeforeBatchQuery: {log.Statement}, TotalTime: {log.ExecutionTime.TotalSeconds} second(s)");
        }

        public void BeforeCount(CancellableTraceLog log)
        {

        }

        public void BeforeCountAll(CancellableTraceLog log)
        {

        }

        public void BeforeDelete(CancellableTraceLog log)
        {

        }

        public void BeforeDeleteAll(CancellableTraceLog log)
        {

        }

        public void BeforeExecuteNonQuery(CancellableTraceLog log)
        {

        }

        public void BeforeExecuteQuery(CancellableTraceLog log)
        {

        }

        public void BeforeExecuteReader(CancellableTraceLog log)
        {

        }

        public void BeforeExecuteScalar(CancellableTraceLog log)
        {

        }

        public void BeforeExists(CancellableTraceLog log)
        {

        }

        public void BeforeInsert(CancellableTraceLog log)
        {

        }

        public void BeforeInsertAll(CancellableTraceLog log)
        {

        }

        public void BeforeMax(CancellableTraceLog log)
        {

        }

        public void BeforeMaxAll(CancellableTraceLog log)
        {

        }

        public void BeforeMerge(CancellableTraceLog log)
        {

        }

        public void BeforeMergeAll(CancellableTraceLog log)
        {

        }

        public void BeforeMin(CancellableTraceLog log)
        {

        }

        public void BeforeMinAll(CancellableTraceLog log)
        {

        }

        public void BeforeQuery(CancellableTraceLog log)
        {

        }

        public void BeforeQueryAll(CancellableTraceLog log)
        {
            Console.WriteLine($"BeforeQueryAll: {log.Statement}, TotalTime: {log.ExecutionTime.TotalSeconds} second(s)");
        }

        public virtual void BeforeQueryMultiple(CancellableTraceLog log)
        {
            Console.WriteLine($"BeforeQueryMultiple: {log.Statement}, TotalTime: {log.ExecutionTime.TotalSeconds} second(s)");
        }

        public void BeforeSum(CancellableTraceLog log)
        {

        }

        public void BeforeSumAll(CancellableTraceLog log)
        {

        }

        public void BeforeTruncate(CancellableTraceLog log)
        {

        }

        public void BeforeUpdate(CancellableTraceLog log)
        {

        }

        public void BeforeUpdateAll(CancellableTraceLog log)
        {

        }
        #endregion
    }
}
