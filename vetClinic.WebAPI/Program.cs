using vetClinic.WebAPI.AppConfiguration.ApplicationExtensions;
using vetClinic.WebAPI.AppConfiguration.ServicesExtensions;
using Serilog;
using vetClinic.Entities;
using Microsoft.EntityFrameworkCore;
using vetClinic.Repository;


var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration(); //Add serilog
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration(); //add api versioning
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration(); //add swagger configuration

builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseSerilogConfiguration(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(); //use swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}