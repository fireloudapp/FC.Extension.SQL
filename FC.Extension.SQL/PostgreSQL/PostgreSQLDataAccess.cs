using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using Npgsql;
using RepoDb;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FC.Extension.SQL.PostgreSQL
{
    /// <summary>
    /// Use this class to access all the basic functions available in the PostgreSQL
    /// </summary>
    /// <typeparam name="TModel">A Model/Entity type</typeparam>
    public class PostgreSQLDataAccess<TModel> : IBaseAccess<TModel> where TModel : class
    {
        string _conString = string.Empty;
        BaseTrace _baseTrace = null;
        PostgresCompiler _postgresCompiler;
        #region Constructor
        public PostgreSQLDataAccess(string connectionString, BaseTrace baseTrace = null)
        {
            _conString = connectionString;
            _baseTrace = baseTrace;
            RepoDb.PostgreSqlBootstrap.Initialize();
            _postgresCompiler = new PostgresCompiler();
        }
        #endregion

        #region IBaseAccess - Base Generic CRUD Operation 
        public TModel Create(TModel model)
        {
            using (var connection = new NpgsqlConnection(_conString))
            {
                var id = connection.Insert(model);
            }
            return model;
        }
        public async Task<TModel> CreateAsync(TModel model)
        {
            using (var connection = new NpgsqlConnection(_conString))
            {
                var id = await connection.InsertAsync(model);
            }
            return model;
        }
        public TModel Update(TModel model)
        {
            using (var connection = new NpgsqlConnection(_conString))
            {
                var id = connection.Update(model);
            }
            return model;
        }
        public async Task<TModel> UpdateAsync(TModel model)
        {
            using (var connection = new NpgsqlConnection(_conString))
            {
                var id = await connection.UpdateAsync(model);
            }
            return model;
        }
        public int Delete(object id)
        {
            //string value = typeof(TModel).Name;
            int noOfRows = 0;
            using (var connection = new NpgsqlConnection(_conString))
            {
                noOfRows = connection.Delete<TModel>(id);
            }
            return noOfRows;
        }
        public async Task<int> DeleteAsync(object id)
        {
            int noOfRows = 0;
            using (var connection = new NpgsqlConnection(_conString))
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
            using (var connection = new NpgsqlConnection(_conString))
            {
                model = connection.Query<TModel>(id).FirstOrDefault();
            }
            return model;
        }
        public async Task<TModel> GetByIdAsync(object id)
        {
            TModel model;
            using (var connection = new NpgsqlConnection(_conString))
            {
                var result = await connection.QueryAsync<TModel>(id);
                model = result.FirstOrDefault();
            }
            return model;
        }
        public IEnumerable<TModel> GetAll()
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new NpgsqlConnection(_conString))
            {
                modelList = connection.QueryAll<TModel>();
            }
            return modelList;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            IEnumerable<TModel> modelList = null;
            using (var connection = new NpgsqlConnection(_conString))
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

            using (var connection = new NpgsqlConnection(_conString))
            {
                model = connection.Query<TModel>(what: condition);
            }
            return model;
        }

        public async Task<IEnumerable<TModel>> GetByConditionAsync(Expression condition)
        {
            IEnumerable<TModel> model = null;

            using (var connection = new NpgsqlConnection(_conString))
            {
                model = await connection.QueryAsync<TModel>(condition);
            }
            return model;
        }

        public IEnumerable<TModel> GetByCondition(QueryField[] whereCondition)
        {
            IEnumerable<TModel> model = null;
            //Ref: https://repodb.net/class/queryfield
            using (var connection = new NpgsqlConnection(_conString))
            {
                model = connection.Query<TModel>(where: whereCondition);
            }
            return model;
        }
        public async Task<IEnumerable<TModel>> GetByConditionAsync(QueryField[] whereCondition)
        {
            IEnumerable<TModel> model = null;
            //Ref: https://repodb.net/class/queryfield
            using (var connection = new NpgsqlConnection(_conString))
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
            using (var connection = new NpgsqlConnection(_conString))
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
            using (var connection = new NpgsqlConnection(_conString))
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
            using (var connection = new NpgsqlConnection(_conString))
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
            using (var connection = new NpgsqlConnection(_conString))
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
                SqlResult sqlResult = _postgresCompiler.Compile(query);
                #region DEBUG
                Console.WriteLine($"ExecuteQuery : {sqlResult.ToString()}");
                #endregion
                using (var connection = new NpgsqlConnection(_conString))
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
                SqlResult sqlResult = _postgresCompiler.Compile(query);
                #region DEBUG
                Console.WriteLine($"ExecuteQuery : {sqlResult.ToString()}");
                #endregion
                using (var connection = new NpgsqlConnection(_conString))
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
            using (var connection = new NpgsqlConnection(_conString))
            {
                noOfRecords = connection.CountAll<TModel>();
            }
            return noOfRecords;
        }

        public async Task<long> GetRecordCountAsync()
        {
            long noOfRecords = 0;
            using (var connection = new NpgsqlConnection(_conString))
            {
                noOfRecords = await connection.CountAllAsync<TModel>();
            }
            return noOfRecords;
        }
        #endregion
    }
}
