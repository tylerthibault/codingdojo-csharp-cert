# Console
- create new console app
```
dotnet new console -o appName
```
- run the app
```
dotnet run
```

# Web
- create new web app
```
dotnet new web --no-https -o AppName
```

> auto restart server when change happens
```
dotnet watch run
```

## Setting up MVC

### Program.cs
`add the following lines`
```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();