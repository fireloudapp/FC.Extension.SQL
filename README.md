# FC.Extension.SQL


[![Version](https://img.shields.io/nuget/v/FC.Extension.SQL.svg)](https://www.nuget.org/packages/FC.Extension.SQL/)
[![Downloads](https://img.shields.io/nuget/dt/FC.Extension.SQL.svg)](https://www.nuget.org/packages/FC.Extension.SQL/)


✅ **Project status: active**.

FC.Extension.SQL is a library which adds reduces the coding effort for the development team in terms of handling SQL Basic functionality. You may required literally a single line of code to handle DB Operation.

This library supports 
+ SQL Server
+ PostgreSQL 
+ MySQL Server
+ SQLite


## Download

- [NuGet](https://www.nuget.org/packages/FC.Extension.SQL/): Install-Package FC.Extension.SQL

## Features

- Ready to use in the project as an extension
- CRUD for SQL Server, PostgreSQL, MySQL, SQLite
- You can pass Fluent Query to execute any Query
- No Worry about the Language(SQL Server, SQLite/PostgreSQL/MySQL)
- Uses SQLkata to receive as Fluent Query.
- Targets .NET Core 3.1+
- Dependent on RepoDB & SQLkata.

## Usage

### Quick start
#### Step 1: Setup the Package

```csharp
Install-Package FC.Extension.SQL
```

#### Step 2:Initial Configuration

```csharp
using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Engine;
using SqlKata;
..

SQLExtension.SQLConfig = new SQLConfig()
	{
	    Compiler = SQLCompiler.PostgreSQL,
	    ConnectionString = "User Id=FCPos;Password=System@1234;Server=localhost;Port=5432;Database=ExtensionTest;",
	    Trace = null
	};
	
var personFake = new Faker<Person>()
                 .RuleFor(o => o.Name, f => f.Person.FirstName)
                 .RuleFor(o => o.Email, f => f.Person.Email);
var person = personFake.Generate();

````

#### Step 3:To Save

```csharp
person = person.Save().Result;
console.Output.WriteLine($"Saved Object : {person.ToJSON<Person>()}");

````
#### Step 4:To Update

```csharp
person.Id = GetIdEntry();
person = person.Update().Result;
console.Output.WriteLine($"Object Updated : {person.ToJSON<Person>()}");

````

#### Step 5:To Delete

```csharp
person.Id = GetIdEntry();
int records = 	person.Delete(person.Id).Result;
console.Output.WriteLine($"Deleted. No of Records : {records}");

````

#### Step 6:To Get Object by Id

```csharp
person.Id = GetIdEntry();
Person per = person.Get(person.Id).Result;
console.Output.WriteLine($"Received Object : {per.ToJSON()}");

````

#### Step 7:To Get Object by Query

```csharp
int id = GetIdEntry();
var personList = person.GetAny(new Query("Person").Where("Id", id)).Result;

foreach (var model in personList)
{
    console.Output.WriteLine($"Queried Object : {model.ToJSON()}");
}

````

#### Step 8:To Get Record Count

```csharp
var personCount = person.GetCount().Result;
console.Output.WriteLine($"Total Records : {personCount}");
````

> ⚠️ All Set. Use the same method for other extension methods.
The full featured document available in the [Gitbook](https://app.gitbook.com/@sr-firecloud/s/fc-extension),
 

## Other Extension

- [AWS](https://www.nuget.org/packages/FC.Extension.AWS, "AWS Extension") 
	* [![Version](https://img.shields.io/nuget/v/FC.Core.Extension.svg)](https://www.nuget.org/packages/FC.Core.Extension/)
[![Downloads](https://img.shields.io/nuget/dt/FC.Core.Extension.svg)](https://www.nuget.org/packages/FC.Core.Extension/)

- [HTTP](https://www.nuget.org/packages/FC.Extension.HTTP/,"HTTP")
	* [![Version](https://img.shields.io/nuget/v/FC.Extension.HTTP.svg)](https://www.nuget.org/packages/FC.Extension.HTTP/)
[![Downloads](https://img.shields.io/nuget/dt/FC.Extension.HTTP.svg)](https://www.nuget.org/packages/FC.Extension.HTTP/)

- [RabbitMQ](https://www.nuget.org/packages/FC.Extension.RabbitMQ/,"RabbitMQ")
	* [![Version](https://img.shields.io/nuget/v/FC.Extension.RabbitMQ.svg)](https://www.nuget.org/packages/FC.Extension.RabbitMQ/)
[![Downloads](https://img.shields.io/nuget/dt/FC.Extension.RabbitMQ.svg)](https://www.nuget.org/packages/FC.Extension.RabbitMQ/)

- [Office](https://www.nuget.org/packages/FC.Extension.Office/,"Office")
	* [![Version](https://img.shields.io/nuget/v/FC.Extension.Office.svg)](https://www.nuget.org/packages/FC.Extension.Office/)
[![Downloads](https://img.shields.io/nuget/dt/FC.Extension.Office.svg)](https://www.nuget.org/packages/FC.Extension.Office/)

- [SQL](https://www.nuget.org/packages/FC.Extension.SQL/,"SQL")
	* [![Version](https://img.shields.io/nuget/v/FC.Extension.SQL.svg)](https://www.nuget.org/packages/FC.Extension.SQL/)
[![Downloads](https://img.shields.io/nuget/dt/FC.Extension.SQL.svg)](https://www.nuget.org/packages/FFC.Extension.SQL/)

>Complete