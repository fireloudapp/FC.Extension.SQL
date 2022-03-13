using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using RepoDb;
using SqlKata;
using SqlKata.Compilers;

namespace FC.Extension.SQL.Mongo
{
    public class MongoDataAccess<TModel> : INoSQLBaseAccess<TModel> where TModel : class
    {
        BaseTrace _baseTrace = null;
        private readonly IMongoCollection<TModel> _modelCollection;
        //private readonly IMongoCollection<PersonMongo> _pCollection;
        
        #region Constructor
        //Ref:https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio#add-an-entity-model
        public MongoDataAccess(SQLConfig sqlConfig)
        {
            _baseTrace = sqlConfig.Trace;
            var settings = MongoClientSettings.FromConnectionString(sqlConfig.ConnectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var mongoClient = new MongoClient(settings);
            var mongoDatabase = mongoClient.GetDatabase(sqlConfig.DataBaseName);
            _modelCollection = mongoDatabase.GetCollection<TModel>(sqlConfig.CollectionName);
            //_pCollection = mongoDatabase.GetCollection<PersonMongo>(sqlConfig.CollectionName);
            //string value = "123564";
            //_pCollection.ReplaceOneAsync(per => per.Id == value, new PersonMongo());
        }
        #endregion

        #region IBaseAccess - Base Generic CRUD Operation
        public TModel Create(TModel model)
        {
            _modelCollection.InsertOne(model);
            return model;
        }
        public async Task<TModel> CreateAsync(TModel model)
        {
            await _modelCollection.InsertOneAsync(model);
            return model;
        }
        public async Task<TModel> UpdateAsync(Expression<Func<TModel, bool>> filter, TModel model)
        {
            await _modelCollection.ReplaceOneAsync(filter, model);
            return model;
        }

        public async Task<string> DeleteAsync(Expression<Func<TModel, bool>> filter, string id)
        {
            var deletedOperation = await _modelCollection.DeleteOneAsync(filter);
            return deletedOperation.ToJson();
        }

        #endregion

        #region Basic Get Operation

        /// <summary>
        /// Get by filter condition eg. (x => x.Id == id), (_ => true) etc..
        /// </summary>
        /// <param name="filter">filter condition </param>
        /// <returns>returns model data</returns>
        public async Task<IEnumerable<TModel>> GetAnyAsync(Expression<Func<TModel, bool>> filter)
        {
            return await _modelCollection.Find(filter).ToListAsync();
        }
        
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _modelCollection.Find(_ => true).ToListAsync();
        }

        #endregion

        #region Basic Scalar Methods
        public async Task<long> GetRecordCountAsync()
        {
            return await _modelCollection.CountDocumentsAsync(new BsonDocument());
        }
        #endregion

        #region Pagination
        //Ref: https://mongodb.github.io/mongo-csharp-driver/2.14/reference/driver/expressions/
        public async Task<IEnumerable<TModel>> GetByPagingAsync<TField>
        (Func<TModel, TField> orderBy, int page = 0,
            int rowsPerBatch = 10) where TField : class
        {
            var query = _modelCollection.Find(_ => true);
            var result  = await query .Skip(page).Limit(rowsPerBatch).ToListAsync();
            result = result.OrderBy(orderBy).ToList();
            return result;
        }

        public async Task<IEnumerable<TModel>> GetByPagingAsync<TField>
        (Func<TModel, TField> orderBy, Expression<Func<TModel, bool>> filter ,  int page = 0,
            int rowsPerBatch = 10) where TField : class
        {
            var query = _modelCollection.Find(filter);
            var result  = await query .Skip(page).Limit(rowsPerBatch).ToListAsync();
            result = result.OrderBy(orderBy).ToList();
            return result;
        }
        #endregion
    }

    
    public class PersonMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}