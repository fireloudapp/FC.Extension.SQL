using Bogus;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FC.Core.Extension.StringHandlers;
using FC.Extension.SQL;
using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Engine;
using SqlKata;

namespace FC.Extension.SQL.Execution.PostgreSQL
{
    /// <summary>
    /// Consume this by typing the command ' .\FC.Extension.SQL.Execution.exe PostgreSQL -h'
    /// </summary>
    [Command("PostgreSQL")]
    public class PostgreSQL_Execution : ICommand
    {
        [CommandOption("Save", 's', Description = "Save a Person")]
        public bool IsSave { get; set; }

        [CommandOption("Update", 'u', Description = "Update a Person")]
        public bool IsUpdate { get; set; }

        [CommandOption("Delete", 'd', Description = "Delete a Person")]
        public bool IsDelete { get; set; }

        [CommandOption("GetById", 'i', Description = "Get a Person by Id")]
        public bool IsGetById { get; set; }

        [CommandOption("Query", 'q', Description = "Execute the Query")]
        public bool IsQuery { get; set; }


        public ValueTask ExecuteAsync(IConsole console)
        {
            var personFake = new Faker<Person>()
                 .RuleFor(o => o.Name, f => f.Person.FirstName)
                 .RuleFor(o => o.Email, f => f.Person.Email);
            var person = personFake.Generate();
            SQLExtension.SQLConfig = new SQLConfig()
            {
                Compiler = SQLCompiler.PostgreSQL,
                ConnectionString = "User Id=FCPos;Password=System@1234;Server=localhost;Port=5432;Database=ExtensionTest;",
                Trace = null
            };
            if (IsSave)
            {
                person = person.Save().Result;
                console.Output.WriteLine($"Saved Object : {person.ToJSON<Person>()}");
            }
            else if (IsUpdate)
            {
                person.Id = GetIdEntry();
                person = person.Update().Result;
                console.Output.WriteLine($"Object Updated : {person.ToJSON<Person>()}");
            }
            else if (IsDelete)
            {
                person.Id = GetIdEntry();
                int records = person.Delete(person.Id).Result;
                console.Output.WriteLine($"Deleted. No of Records : {records}");
            }
            else if (IsGetById)
            {
                person.Id = GetIdEntry();
                Person per = person.Get(person.Id).Result;
                console.Output.WriteLine($"Received Object : {per.ToJSON()}");
            }
            else if (IsQuery)
            {
                int id = GetIdEntry();
                var personList = person.GetAny(new Query("Person").Where("Id", id)).Result;

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
        public int GetIdEntry()
        {
            Console.WriteLine("Enter Person unique Id :");
            int id = int.Parse(Console.ReadLine().ToString());
            return id;
        }

        
    }

    
}
