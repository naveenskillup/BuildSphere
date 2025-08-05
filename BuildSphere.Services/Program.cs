using BuildSphere.Data.DataManager.Sql;
using BuildSphere.Data.Repository.Interfaces;
using BuildSphere.Data.TextFile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<SqlConnectionFactory>( provider => 
{
    var config = provider.GetRequiredService<IConfiguration>();
    var databaseServer = config["Database:Server"];
    var databaseName = config["Database:Name"];
    return new SqlConnectionFactory(databaseServer, databaseName);
});

builder.Services.AddScoped<IProjectRepository, SqlProjectRepository>();
builder.Services.AddScoped<IMilestoneRepository, SqlMilestoneRepository>();
builder.Services.AddScoped<ISpecificationRepository, SqlSpecificationRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();