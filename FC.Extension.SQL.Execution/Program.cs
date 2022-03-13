using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FC.Extension.SQL.Execution
{
    public static class Program
    {
        public static async Task<int> Main() =>
            await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class PersonMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    

    [Command("HellowWorld")]
    public class HelloWorldCommand : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Hello world!");

            // Return default task if the command is not asynchronous
            return default;
        }
    }

    [Command("Log")]
    public class LogCommand : ICommand
    {
        // Order: 0
        [CommandParameter(0, Description = "Value whose logarithm is to be found.")]
        public double Value { get; set; }

        // Name: --base
        // Short name: -b
        [CommandOption("base", 'b', Description = "Logarithm base.")]
        public double Base { get; set; } = 10;

        public ValueTask ExecuteAsync(IConsole console)
        {
            var result = Math.Log(Value, Base);
            console.Output.WriteLine($"Value : {Value} Base {Base}");
            console.Output.WriteLine(result);

            return default;
        }

    }
}
