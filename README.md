# ASPNET-CRUD-MVC

In this project I used the follow technologies:
- SQL Server Database
- Entity Framework(ORM)
- Razor
- DataAnnotations
- C#
- NetCore 6.0

# First of all!

To execute this project you need a SQL Server Database (I used docker image!), then... install it.

Open `appsettings.json` and **change** the parameters Server=**localhost**;Database=**Db_Contacts**;User Id=**sa**;Password=**bigStrongPwd**
```
"ConnectionStrings": {
    "DataBase": "Server=localhost;Database=Db_Contacts;User Id=sa;Password=bigStrongPwd"
  }
```

Well, I'm using [Entity Framework](https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx) and `code first` we need to execute some `commands` to **create** the `migrations` and `database` automatically.

I called my database as `DatabaseContext` then we need to execute this command in Package Manager Console:

`add-migration MyFirstMigration -Context DatabaseContext` 

after

`Update-Database`
