# SlopShop

A backend for your online grocery shop frontends, built with C#, ASP.NET and SQL Server.

## To run:
- Clone this repo.
- Set the secrets for the connection string to the SQL server database.
```bash
dotnet user-secrets set ConnectionStrings:SlopShopDB "Data Source=localhost;Database=SlopShopDB;User Id=<username>;Password=<password>;MultipleActiveResultSets=true;Encrypt=false
```

Next steps are easier done using an IDE like Rider or Visual Studio. But if you insist using the terminal and the dotnet CLI, proceed with the below:

- Build the project.
```
dotnet build SlopShop.csproj
```
- Run the server from the compiled executables

## Note:
This project is made as a hobby for educational purposes, and is **NOT** a commercial application.