using RepoDb;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FC.Extension.SQL.Interface
{
    public interface IBaseAccess<TModel> where TModel : class
    {
        #region Basic CRUD

        public TModel Create(TModel model);
        public Task<TModel> CreateAsync(TModel model);
        public TModel Update(TModel model);
        public Task<TModel> UpdateAsync(TModel model);
        public int Delete(object id);
        public Task<int> DeleteAsync(object id);

        #endregion

        #region Basic Get Methods

        public TModel GetById(object id);
        public Task<TModel> GetByIdAsync(object id);
        public IEnumerable<TModel> GetAll();
        public Task<IEnumerable<TModel>> GetAllAsync();

        #endregion

        #region Condition Executions
        public IEnumerable<TModel> GetByCondition(Expression condition);
        public Task<IEnumerable<TModel>> GetByConditionAsync(Expression condition);
        public IEnumerable<TModel> GetByCondition(QueryField[] whereCondition);
        public Task<IEnumerable<TModel>> GetByConditionAsync(QueryField[] whereCondition);
        

        #endregion

        #region Paginations

        public IEnumerable<TModel> GetByPaging(IEnumerable<OrderField> orderBy, int page = 0, int rowsPerBatch = 10);
        public IEnumerable<TModel> GetByPaging(IEnumerable<OrderField> orderBy, Expression<Func<TModel, bool>> filterCondition, int page = 0, int rowsPerBatch = 10);

        public Task<IEnumerable<TModel>> GetByPagingAsync(IEnumerable<OrderField> orderBy, int page = 0, int rowsPerBatch = 10);
        public Task<IEnumerable<TModel>> GetByPagingAsync(IEnumerable<OrderField> orderBy, Expression<Func<TModel, bool>> filterCondition, int page = 0, int rowsPerBatch = 10);


        #endregion

        #region General Execution
        public Task<IEnumerable<TModel>> ExecuteQuery(Query query);
        public Task<IEnumerable<TModel>> ExecuteQuery<T>(Query query) where T : class;
        #endregion

        #region Basic Scalar Methods

        public long GetRecordCount();
        public Task<long> GetRecordCountAsync();

        #endregion

        #region Dangerous Methods

        public int Truncate();
        public Task<long> TruncateAsync();
        public int DeleteAll();

        public bool CreteTable(string sqlQuery);
        public bool DeleteTable(string sqlQuery);


        #endregion
        
    }

    public interface INoSQLBaseAccess<TModel> where TModel : class
    {
        #region Basic CRUD
        public TModel Create(TModel model);
        public Task<TModel> CreateAsync(TModel model);
        public Task<TModel> UpdateAsync(Expression<Func<TModel, bool>> filter, TModel model);
        public Task<string> DeleteAsync(Expression<Func<TModel, bool>> filter, string id);
        #endregion
        
        #region Basic Get Methods

        public Task<IEnumerable<TModel>> GetAnyAsync(Expression<Func<TModel, bool>> filter);
        public Task<IEnumerable<TModel>> GetAllAsync();

        #endregion
        
        #region Basic Scalar Methods
        public Task<long> GetRecordCountAsync();

        #endregion

        #region Pagination

        Task<IEnumerable<TModel>> GetByPagingAsync<TField>
        (Func<TModel, TField> orderBy, int page = 0,
            int rowsPerBatch = 10) where TField : class;
        public Task<IEnumerable<TModel>>  GetByPagingAsync<TField>
        (Func<TModel, TField> orderBy, Expression<Func<TModel, bool>> filter, int page = 0,
            int rowsPerBatch = 10) where TField : class;


        #endregion

    }
}
