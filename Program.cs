var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello from Sample .NET App running in Docker!");

app.RunAsync();