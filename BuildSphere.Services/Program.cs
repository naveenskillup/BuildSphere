using System;
using System.Text;
using BuildSphere.Core;
using BuildSphere.Core.Interfaces;
using BuildSphere.Core.Services;
using BuildSphere.Data.DataManager.Sql;
using BuildSphere.Services.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = config["Jwt:Issuer"],    
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),

            ClockSkew = TimeSpan.Zero // remove default 5 min tolerance
        };
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();