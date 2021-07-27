using CliFx;
using System;
using System.Threading.Tasks;

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
}
