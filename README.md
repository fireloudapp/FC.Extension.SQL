<a name='assembly'></a>
# FC.Extension.SQL

## Contents

- [BaseTrace](#T-FC-Extension-SQL-Helper-BaseTrace 'FC.Extension.SQL.Helper.BaseTrace')
- [DeleteHandler](#T-FC-Extension-SQL-Engine-DeleteHandler 'FC.Extension.SQL.Engine.DeleteHandler')
  - [Delete\`\`1(model,id)](#M-FC-Extension-SQL-Engine-DeleteHandler-Delete``1-``0,System-Object- 'FC.Extension.SQL.Engine.DeleteHandler.Delete``1(``0,System.Object)')
- [GetAllHandler](#T-FC-Extension-SQL-Engine-GetAllHandler 'FC.Extension.SQL.Engine.GetAllHandler')
  - [GetAll\`\`1(model)](#M-FC-Extension-SQL-Engine-GetAllHandler-GetAll``1-``0- 'FC.Extension.SQL.Engine.GetAllHandler.GetAll``1(``0)')
- [GetAnyHandler](#T-FC-Extension-SQL-Engine-GetAnyHandler 'FC.Extension.SQL.Engine.GetAnyHandler')
  - [GetAny\`\`1(model,query)](#M-FC-Extension-SQL-Engine-GetAnyHandler-GetAny``1-``0,SqlKata-Query- 'FC.Extension.SQL.Engine.GetAnyHandler.GetAny``1(``0,SqlKata.Query)')
- [GetByIdHandler](#T-FC-Extension-SQL-Engine-GetByIdHandler 'FC.Extension.SQL.Engine.GetByIdHandler')
  - [Get\`\`1(model,id)](#M-FC-Extension-SQL-Engine-GetByIdHandler-Get``1-``0,System-Object- 'FC.Extension.SQL.Engine.GetByIdHandler.Get``1(``0,System.Object)')
- [MySQLDataAccess\`1](#T-FC-Extension-SQL-MySQL-MySQLDataAccess`1 'FC.Extension.SQL.MySQL.MySQLDataAccess`1')
- [PostgreSQLDataAccess\`1](#T-FC-Extension-SQL-PostgreSQL-PostgreSQLDataAccess`1 'FC.Extension.SQL.PostgreSQL.PostgreSQLDataAccess`1')
- [SQLiteDataAccess\`1](#T-FC-Extension-SQL-SQLServer-SQLiteDataAccess`1 'FC.Extension.SQL.SQLServer.SQLiteDataAccess`1')
- [SQServerDataAccess\`1](#T-FC-Extension-SQL-SQLServer-SQServerDataAccess`1 'FC.Extension.SQL.SQLServer.SQServerDataAccess`1')
- [SaveHandler](#T-FC-Extension-SQL-Engine-SaveHandler 'FC.Extension.SQL.Engine.SaveHandler')
  - [Save\`\`1(model)](#M-FC-Extension-SQL-Engine-SaveHandler-Save``1-``0- 'FC.Extension.SQL.Engine.SaveHandler.Save``1(``0)')

<a name='T-FC-Extension-SQL-Helper-BaseTrace'></a>
## BaseTrace `type`

##### Namespace

FC.Extension.SQL.Helper

##### Summary

Trace class which captures traces in console, which can be extended to any trace implementation.

<a name='T-FC-Extension-SQL-Engine-DeleteHandler'></a>
## DeleteHandler `type`

##### Namespace

FC.Extension.SQL.Engine

##### Summary

Class that handles Delete operation

<a name='M-FC-Extension-SQL-Engine-DeleteHandler-Delete``1-``0,System-Object-'></a>
### Delete\`\`1(model,id) `method`

##### Summary

Delete the object

##### Returns

returns no of records that has been deleted

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [\`\`0](#T-``0 '``0') | Entity model object |
| id | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An Unique id that will be deleted |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Entity/Model Type |

<a name='T-FC-Extension-SQL-Engine-GetAllHandler'></a>
## GetAllHandler `type`

##### Namespace

FC.Extension.SQL.Engine

##### Summary

A Class that gats all the data from the given model.

<a name='M-FC-Extension-SQL-Engine-GetAllHandler-GetAll``1-``0-'></a>
### GetAll\`\`1(model) `method`

##### Summary

A Get method that returns all the data from the given model. Use this for small table which is lesser then 1K Record.

##### Returns

returns all the model.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [\`\`0](#T-``0 '``0') | Entity model object |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Entity/Model Type |

<a name='T-FC-Extension-SQL-Engine-GetAnyHandler'></a>
## GetAnyHandler `type`

##### Namespace

FC.Extension.SQL.Engine

##### Summary

A Class that handles and executes any query and retrieves data

<a name='M-FC-Extension-SQL-Engine-GetAnyHandler-GetAny``1-``0,SqlKata-Query-'></a>
### GetAny\`\`1(model,query) `method`

##### Summary

A Get method that returns data by a given query
Ref:

##### Returns

returns the model based on the query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [\`\`0](#T-``0 '``0') | Entity model object |
| query | [SqlKata.Query](#T-SqlKata-Query 'SqlKata.Query') | A query generated through SQLKata |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Entity/Model Type |

<a name='T-FC-Extension-SQL-Engine-GetByIdHandler'></a>
## GetByIdHandler `type`

##### Namespace

FC.Extension.SQL.Engine

##### Summary

A Class that handles Get Object

<a name='M-FC-Extension-SQL-Engine-GetByIdHandler-Get``1-``0,System-Object-'></a>
### Get\`\`1(model,id) `method`

##### Summary

A Get method returns the model data by Id

##### Returns

returns the model with the given id.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [\`\`0](#T-``0 '``0') | Entity model object |
| id | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An Unique id that will be retrieve model |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Entity/Model Type |

<a name='T-FC-Extension-SQL-MySQL-MySQLDataAccess`1'></a>
## MySQLDataAccess\`1 `type`

##### Namespace

FC.Extension.SQL.MySQL

##### Summary

Use this class to access all the basic functions available in the MySQL

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | A Model/Entity type |

<a name='T-FC-Extension-SQL-PostgreSQL-PostgreSQLDataAccess`1'></a>
## PostgreSQLDataAccess\`1 `type`

##### Namespace

FC.Extension.SQL.PostgreSQL

##### Summary

Use this class to access all the basic functions available in the PostgreSQL

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | A Model/Entity type |

<a name='T-FC-Extension-SQL-SQLServer-SQLiteDataAccess`1'></a>
## SQLiteDataAccess\`1 `type`

##### Namespace

FC.Extension.SQL.SQLServer

##### Summary

Use this class to access all the basic functions available in the SQLite

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | A Model/Entity type |

<a name='T-FC-Extension-SQL-SQLServer-SQServerDataAccess`1'></a>
## SQServerDataAccess\`1 `type`

##### Namespace

FC.Extension.SQL.SQLServer

##### Summary

Use this class to access all the basic functions available in the SQL Server

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | A Model/Entity type |

<a name='T-FC-Extension-SQL-Engine-SaveHandler'></a>
## SaveHandler `type`

##### Namespace

FC.Extension.SQL.Engine

##### Summary

Class that handles Save operation

<a name='M-FC-Extension-SQL-Engine-SaveHandler-Save``1-``0-'></a>
### Save\`\`1(model) `method`

##### Summary

Saves the object

##### Returns

returns the model with saved data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [\`\`0](#T-``0 '``0') | Entity model object |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Entity/Model Type |
