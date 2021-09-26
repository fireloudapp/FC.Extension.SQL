using RepoDb;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FC.Extension.SQL.Interface
{
    public interface IBaseAccess<TModel> where TModel : class
    {
        public TModel Create(TModel model);
        public Task<TModel> CreateAsync(TModel model);
        public TModel Update(TModel model);
        public Task<TModel> UpdateAsync(TModel model);
        public int Delete(object id);
        public Task<int> DeleteAsync(object id);
        public TModel GetById(object id);
        public Task<TModel> GetByIdAsync(object id);
        public IEnumerable<TModel> GetAll();
        public Task<IEnumerable<TModel>> GetAllAsync();
        public IEnumerable<TModel> GetByCondition(Expression condition);
        public Task<IEnumerable<TModel>> GetByConditionAsync(Expression condition);
        public IEnumerable<TModel> GetByCondition(QueryField[] whereCondition);
        public Task<IEnumerable<TModel>> GetByConditionAsync(QueryField[] whereCondition);

        public IEnumerable<TModel> GetByPaging(IEnumerable<OrderField> orderBy, int page = 0, int rowsPerBatch = 10);
        public IEnumerable<TModel> GetByPaging(IEnumerable<OrderField> orderBy, Expression<Func<TModel, bool>> filterCondition, int page = 0, int rowsPerBatch = 10);

        public Task<IEnumerable<TModel>> GetByPagingAsync(IEnumerable<OrderField> orderBy, int page = 0, int rowsPerBatch = 10);
        public Task<IEnumerable<TModel>> GetByPagingAsync(IEnumerable<OrderField> orderBy, Expression<Func<TModel, bool>> filterCondition, int page = 0, int rowsPerBatch = 10);
        public Task<IEnumerable<TModel>> ExecuteQuery(Query query);
        public Task<IEnumerable<TModel>> ExecuteQuery<T>(Query query) where T : class;
        public long GetRecordCount();
        public Task<long> GetRecordCountAsync();

        public int Truncate();
        public Task<long> TruncateAsync();
        public int DeleteAll();

        public bool CreteTable(string sqlQuery);
        public bool DeleteTable(string sqlQuery);

    }

    //public interface IDangerExecution<TModel> where TModel : class
    //{

    //}
}
