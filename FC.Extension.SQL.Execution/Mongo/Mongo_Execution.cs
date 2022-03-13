using Bogus;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using FC.Core.Extension.StringHandlers;
using FC.Extension.SQL.Engine;
using FC.Extension.SQL.Helper;
using SqlKata;
using System;
using System.Threading.Tasks;
using FC.Extension.SQL.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FC.Extension.SQL.Execution.Mongo
{
    /// <summary>
    /// Consume this by typing the command ' .\FC.Extension.SQL.Execution.exe MongoDB -h'
    /// </summary>
    [Command("MongoDB")]
    public class Mongo_Execution : ICommand
    {
        [CommandOption("Save", 's', Description = "Save a Person")]
        public bool IsSave { get; set; }

        [CommandOption("Update", 'u', Description = "Update a Person")]
        public bool IsUpdate { get; set; }

        [CommandOption("Delete", 'd', Description = "Delete a Person")]
        public bool IsDelete { get; set; }

        [CommandOption("GetById", 'i', Description = "Get a Person by Id")]
        public bool IsGetById { get; set; }
        
        [CommandOption("GetAll", 'g', Description = "Get all Records of a Person")]
        public bool IsGetAll { get; set; }

        [CommandOption("Query", 'q', Description = "Execute the Query")]
        public bool IsQuery { get; set; }

        [CommandOption("Count", 'c', Description = "Get the Record count")]
        public bool IsGetCount { get; set; }
        
        [CommandOption("Pagination", 'p', Description = "Get person data by Page")]
        public bool IsPaged { get; set; }

        public ValueTask ExecuteAsync(IConsole console)
        {
            var personFake = new Faker<PersonMongo>()
                 .RuleFor(o => o.Name, f => f.Person.FirstName)
                 .RuleFor(o => o.Email, f => f.Person.Email);
            var person = personFake.Generate();
            
            SQLExtension.SQLConfig = new SQLConfig()
            {
                Compiler = SQLCompiler.MongoDB,
                DBType = DBType.NoSQL,
                ConnectionString = "mongodb+srv://fc_client_admin:fc.Serverless.mongo@cluster0.acxm4.mongodb.net/ClientDB?retryWrites=true&w=majority&connect=replicaSet",
                DataBaseName = "ClientDB",
                CollectionName = "FC.Clients"
            };
            if (IsSave)
            {
                person = person.Save().Result;
                console.Output.WriteLine($"Saved Object : {person.ToJSON<PersonMongo>()}");
            }
            else if (IsUpdate)
            {
                person.Id = GetIdEntry();
                Console.WriteLine($"Unique Id : {person.Id}");
                person = person.Update(per => per.Id == person.Id).Result;
                console.Output.WriteLine($"Object Updated : {person.ToJSON<PersonMongo>()}");
            }
            else if (IsDelete)
            {
                person.Id = GetIdEntry();
                string records = person.Delete(per => per.Id == person.Id, person.Id).Result;
                console.Output.WriteLine($"Deleted. No of Records : {records}");
            }
            else if (IsGetAll)
            {
                var result = person.GetAll().Result;
                foreach (var persons  in result)
                {
                    console.Output.WriteLine(persons.ToJson());
                }
                console.Output.WriteLine("All Records returned.");
            }
            else if (IsGetById)
            {
                person.Id = GetIdEntry();
                PersonMongo per = person.Get(person.Id).Result;
                console.Output.WriteLine($"Received Object : {per.ToJSON()}");
            }
            else if (IsQuery)
            {
                string id = GetIdEntry();
                var personList = person.GetAny
                    (per => per.Id == id).Result;
                foreach (var model in personList)
                {
                    console.Output.WriteLine($"Queried Object : {model.ToJSON()}");
                }
            }
            else if (IsGetCount)
            {
                var personCount = person.GetCount().Result;
                console.Output.WriteLine($"Total Records : {personCount}");
            }
            else if (IsPaged)
            {
                INoSQLBaseAccess<PersonMongo> baseAccess = SQLExtension.GetNoSQLCompiler<PersonMongo>();
                var personList =  baseAccess.GetByPagingAsync(per => per.Name, 0, 5).Result;
                foreach (var model in personList)
                {
                    console.Output.WriteLine($"Queried Object : {model.ToJSON()}");
                }
            }
            

            return default;
        }
        /// <summary>
        /// Get the Id by key entry
        /// </summary>
        /// <returns></returns>
        public string GetIdEntry()
        {
            Console.WriteLine("Enter Person unique Id :");
            string id = Console.ReadLine();
            return id;
        }

        
    }
}