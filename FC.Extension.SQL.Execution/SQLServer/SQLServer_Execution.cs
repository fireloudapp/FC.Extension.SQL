using Bogus;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FC.Core.Extension.StringHandlers;
using FC.Extension.SQL.Engine;
using FC.Extension.SQL.Helper;

namespace FC.Extension.SQL.Execution.PostgreSQL
{
    [Command("SQLServer")]
    public class SQLServer_Execution : ICommand
    {
        [CommandOption("Save", 's', Description = "Save a Person")]
        public bool IsSave { get; set; }

        [CommandOption("Update", 'u', Description = "Update a Person")]
        public bool IsUpdate { get; set; }

        [CommandOption("Delete", 'd', Description = "Delete a Person")]
        public bool IsDelete { get; set; }

        [CommandOption("GetById", 'i', Description = "Get a Person by Id")]
        public bool IsGetById { get; set; }

        public ValueTask ExecuteAsync(IConsole console)
        {
            var personFake = new Faker<Person>()
                 .RuleFor(o => o.Name, f => f.Person.FullName)
                 .RuleFor(o => o.Email, f => f.Person.Email);
            var person = personFake.Generate();
            SQLExtension.SQLConfig = new SQLConfig()
            {
                Compiler = SQLCompiler.SQLServer,
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
                person.Id = 1;
                person = person.Update().Result;
                console.Output.WriteLine($"Object Updated : {person.ToJSON<Person>()}");
            }
            else if (IsDelete)
            {
                person.Id = 1;
                int records = person.Delete(person.Id).Result;
                console.Output.WriteLine($"Deleted. No of Records : {records}");
            }
            else if (IsGetById)
            {
                console.Output.WriteLine("Enter Person unique Id :");
                int id = int.Parse(Console.ReadKey().ToString());
                person.Id = id;
                Person per = person.Get(person.Id).Result;
                console.Output.WriteLine($"Received Object : {per.ToJSON()}");
            }

            return default;
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
    }
}
