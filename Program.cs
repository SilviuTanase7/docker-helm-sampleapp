using System;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello from Sample .NET App running in Docker!");

app.Run();



namespace SampleApp
{
class Program
{
static void Main(string[] args)
{
    Console.WriteLine("Hello, World!"); 
}
}
}
