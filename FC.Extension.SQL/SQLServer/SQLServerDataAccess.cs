using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using Npgsql;
using RepoDb;
using SqlKata.Compilers;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;

namespace FC.Extension.SQL.SQLServer
{
    /// <summary>
    /// Use this class to access all the basic functions available in the SQL Server
    /// </summary>
    /// <typeparam name="TModel">A Model/Entity type</typeparam>
    public class SQLServerDataAccess<TModel> : IBaseAccess<TModel> where TModel : class
    {
        string _conString = string.Empty;
        BaseTrace _baseTrace = null;
        SqlServerCompiler _sqlServerCompiler;
        #region Constructor
        public SQLServerDataAccess(string connectionString, BaseTrace baseTrace = null)
        {
            _conString = connectionString;
            _baseTrace = baseTrace;
            RepoDb.SqlServerBootstrap.Initialize();
            _sqlServerCompiler = new SqlServerCompiler();
        }
        #endregion

        #region IBaseAccess - Base Generic CRUD Operation 
        public TModel Create(TModel model)
        {
            using (var connection = new SqlConnection(_conString))
            {
                var id = connection.Insert(model);
            }
            return model;
        }
        public async Task<TModel> CreateAsync(TModel model)
        {
            using (var connection = new SqlConnection(_conString))
            {
                var id = await connection.InsertAsync(model);
            }
            return model;
        }
        public TModel Update(TModel model)
        {
            using (var connection = new SqlConnection(_conString))
            {
                var id = connection.Update(model);
            }
            return model;
        }
        public async Task<TModel> UpdateAsync(TModel model)
        {
            using (var connection = new SqlConnection(_conString))
            {
                var id = await connection.UpdateAsync(model);
            }
            return model;
        }
        public int Delete(object id)
        {
            //string value = typeof(TModel).Name;
            int noOfRows = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRows = connection.Delete<TModel>(id);
            }
            return noOfRows;
        }
        public async Task<int> DeleteAsync(object id)
        {
            int noOfRows = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRows = await connection.DeleteAsync<TModel>(id);
            }
            return noOfRows;
        }
        #endregion

        #region GET Basic Operation
        public TModel GetById(object id)
        {
            TModel model;
            using (var connection = new SqlConnection(_conString))
            {
                model = connection.Query<TModel>(id).FirstOrDefault();
            }
            return model;
        }
        public async Task<TModel> GetByIdAsync(object id)
        {
            TModel model;
            using (var connection = new SqlConnection(_conString))
            {
                var result = await connection.QueryAsync<TModel>(id);
                model = result.FirstOrDefault();
            }
            return model;
        }
        public IEnumerable<TModel> GetAll()
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new SqlConnection(_conString))
            {
                modelList = connection.QueryAll<TModel>();
            }
            return modelList;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new SqlConnection(_conString))
            {
                modelList = await connection.QueryAllAsync<TModel>();
            }
            return modelList;
        }

        #endregion

        #region Get By Condition
        public IEnumerable<TModel> GetByCondition(Expression condition)
        {
            IEnumerable<TModel> model = null;

            using (var connection = new SqlConnection(_conString))
            {
                model = connection.Query<TModel>(what: condition);
            }
            return model;
        }

        public async Task<IEnumerable<TModel>> GetByConditionAsync(Expression condition)
        {
            IEnumerable<TModel> model = null;

            using (var connection = new SqlConnection(_conString))
            {
                model = await connection.QueryAsync<TModel>(condition);
            }
            return model;
        }

        public IEnumerable<TModel> GetByCondition(QueryField[] whereCondition)
        {
            IEnumerable<TModel> model = null;
            //Ref: https://repodb.net/class/queryfield
            using (var connection = new SqlConnection(_conString))
            {
                model = connection.Query<TModel>(where: whereCondition);
            }
            return model;
        }
        public async Task<IEnumerable<TModel>> GetByConditionAsync(QueryField[] whereCondition)
        {
            IEnumerable<TModel> model = null;
            //Ref: https://repodb.net/class/queryfield
            using (var connection = new SqlConnection(_conString))
            {
                model = await connection.QueryAsync<TModel>(where: whereCondition);
            }
            return model;
        }

        #endregion

        #region Get Paging - Operation

        public IEnumerable<TModel> GetByPaging(IEnumerable<OrderField> orderBy, int page = 0, int rowsPerBatch = 10)
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new SqlConnection(_conString))
            {
                modelList = connection.BatchQuery<TModel>
                    (
                    page: page,
                    rowsPerBatch: rowsPerBatch,
                    orderBy: orderBy,
                    where: (object)null,//In this where is a object
                                        // if no where condition assign eg. where: (object)null
                    trace: _baseTrace
                    );
            }
            return modelList;
        }
        public IEnumerable<TModel> GetByPaging(IEnumerable<OrderField> orderBy, Expression<Func<TModel, bool>> filterCondition, int page = 0, int rowsPerBatch = 10)
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new SqlConnection(_conString))
            {
                modelList = connection.BatchQuery<TModel>
                       (
                       page: page,
                       rowsPerBatch: rowsPerBatch,
                       orderBy: orderBy,
                       where: filterCondition,//In this where is a expression.
                                              //eg. if we have where condition eg. where: e => e.Name == true
                       trace: _baseTrace
                       );
            }
            return modelList;
        }

        public async Task<IEnumerable<TModel>> GetByPagingAsync(IEnumerable<OrderField> orderBy, int page = 0, int rowsPerBatch = 10)
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new SqlConnection(_conString))
            {
                modelList = await connection.BatchQueryAsync<TModel>
                    (
                    page: page,
                    rowsPerBatch: rowsPerBatch,
                    orderBy: orderBy,
                    where: (object)null,//In this where is a object
                                        // if no where condition assign eg. where: (object)null
                    trace: _baseTrace
                    );
            }
            return modelList;
        }
        public async Task<IEnumerable<TModel>> GetByPagingAsync(IEnumerable<OrderField> orderBy, Expression<Func<TModel, bool>> filterCondition, int page = 0, int rowsPerBatch = 10)
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new SqlConnection(_conString))
            {
                modelList = await connection.BatchQueryAsync<TModel>
                       (
                       page: page,
                       rowsPerBatch: rowsPerBatch,
                       orderBy: orderBy,
                       where: filterCondition,//In this where is a expression.
                                              //eg. if we have where condition eg. where: e => e.Name == true

                       trace: _baseTrace
                       );
                //await connection.BatchQueryAsync<TModel>()
            }
            return modelList;
        }

        #endregion

        #region Basic Search
        public async Task<IEnumerable<TModel>> ExecuteQuery(Query query)
        {
            IEnumerable<TModel> model = null;
            try
            {
                SqlResult sqlResult = _sqlServerCompiler.Compile(query);
                #region DEBUG
                Console.WriteLine($"ExecuteQuery : {sqlResult.ToString()}");
                #endregion
                using (var connection = new SqlConnection(_conString))
                {
                    model = await connection.ExecuteQueryAsync<TModel>(sqlResult.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return model;
        }
        public async Task<IEnumerable<TModel>> ExecuteQuery<T>(Query query) where T : class
        {
            IEnumerable<TModel> model = null;
            try
            {
                SqlResult sqlResult = _sqlServerCompiler.Compile(query);
                #region DEBUG
                Console.WriteLine($"ExecuteQuery : {sqlResult.ToString()}");
                #endregion
                using (var connection = new SqlConnection(_conString))
                {
                    model = await connection.ExecuteQueryAsync<TModel>(sqlResult.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return model;
        }
        #endregion

        #region Scalar Operation
        public long GetRecordCount()
        {
            long noOfRecords = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRecords = connection.CountAll<TModel>();
            }
            return noOfRecords;
        }

        public async Task<long> GetRecordCountAsync()
        {
            long noOfRecords = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRecords = await connection.CountAllAsync<TModel>();
            }
            return noOfRecords;
        }
        #endregion

        #region IDangerExecution Implementation

        public async Task<long> TruncateAsync()
        {
            long noOfRecords = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRecords = await connection.TruncateAsync<TModel>();
            }
            return noOfRecords;
        }

        public int DeleteAll()
        {
            int noOfRowsDeleted = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRowsDeleted = connection.DeleteAll<TModel>();
            }
            return noOfRowsDeleted;
        }

        public int Truncate()
        {
            int noOfRowsTruncated = 0;
            using (var connection = new SqlConnection(_conString))
            {
                noOfRowsTruncated = connection.Truncate<TModel>();
            }
            return noOfRowsTruncated;
        }

        public bool CreteTable(string sqlQuery)
        {
            return ExecuteSQLQuery(sqlQuery);
        }

        public bool DeleteTable(string sqlQuery)
        {
            return ExecuteSQLQuery(sqlQuery);
        }

        private bool ExecuteSQLQuery(string sqlQuery)
        {
            bool result = false;
            using (var connection = new SqlConnection(_conString))
            {
                var value = connection.ExecuteNonQuery(sqlQuery);
                result = true;
            }
            return result;
        }
        #endregion
    }
}
