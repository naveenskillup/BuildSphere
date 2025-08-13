using BuildSphere.Core;
using BuildSphere.Core.Interfaces;
using BuildSphere.Core.Services;
using BuildSphere.Data.DataManager.Sql;
using BuildSphere.Services.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<SqlConnectionFactory>( provider => 
{
    var config = provider.GetRequiredService<IConfiguration>();
    var databaseServer = config["Database:Server"];
    var databaseName = config["Database:Name"];
    return new SqlConnectionFactory(databaseServer, databaseName);
});

builder.Services.AddDataServices();
builder.Services.AddScoped<IProjectService, ProjectService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();