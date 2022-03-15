
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Shouldly;

namespace FC.Extension.SQL.xTest;

public class TemplateTest
{
    private readonly ITestOutputHelper _output;
    public TemplateTest(ITestOutputHelper output)
    {
        this._output = output;
    }
    [Fact]
    public async Task Age_Test()
    {
        // DateTime dtAge = new DateTime(2016, 02, 25);
        // int age = dtAge.Age();           
        // _output.WriteLine($"Age of person born at {dtAge.ToLongDateString()} is '{age}'");
        // age.ShouldBePositive();
        //
        // dtAge = new DateTime(1984, 06, 14);
        // age = dtAge.Age();
        // _output.WriteLine($"Age of person born at {dtAge.ToLongDateString()} is '{age}'");
        // age.ShouldBePositive();
        return;
    }
}