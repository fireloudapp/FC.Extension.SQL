using Bogus;
using FC.Core.Extension.StringHandlers;
using FC.Extension.SQL.Engine;
using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using FC.Extension.SQL.Mongo;
using Xunit;
using Xunit.Abstractions;

namespace FC.Extension.SQL.xTest;

public class MongoDBTest
{
    private readonly ITestOutputHelper _output;
    public MongoDBTest(ITestOutputHelper output)
    {
        this._output = output;
        SQLExtension.SQLConfig = new SQLConfig()
        {
            Compiler = SQLCompiler.MongoDB,
            DBType = DBType.NoSQL,
            ConnectionString = "mongodb+srv://fc_client_admin:fc.Serverless.mongo@cluster0.acxm4.mongodb.net/ClientDB?retryWrites=true&w=majority&connect=replicaSet",
            DataBaseName = "ClientDB",
            CollectionName = "FC.Clients"
        };
    }
    
    [Fact]
    public void GetByPagingAsync_Test()
    {
        INoSQLBaseAccess<PersonMongo> baseAccess = SQLExtension.GetNoSQLCompiler<PersonMongo>();
        var personList =  baseAccess.GetByPagingAsync(per => per.Name, 0, 5).Result;
        foreach (var model in personList)
        {
            _output.WriteLine($"Queried Object : {model.ToJSON()}");
        }
    }
    
    [Fact]
    public void Save_Test()
    {
        var personFake = new Faker<PersonMongo>()
            .RuleFor(o => o.Name, f => f.Person.FirstName)
            .RuleFor(o => o.Email, f => f.Person.Email);
        var person = personFake.Generate();
        person = person.Save().Result;
        _output.WriteLine($"Saved Object : {person.ToJSON<PersonMongo>()}");
    }
    
}