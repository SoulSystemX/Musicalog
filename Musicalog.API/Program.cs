using System.Data.Common;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Musicalog.Core.Interfaces;
using Musicalog.Core.Services;
using Musicalog.Data.Context;
using Musicalog.Data.Extensions;
using Musicalog.Data.Interfaces;
using Musicalog.Data.Migrations;
using Musicalog.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
    .AddFluentMigratorCore()
    .ConfigureRunner(c => c.AddSqlServer()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("MasterConnection"))
        .ScanIn(typeof(Database).Assembly).For.Migrations()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("SqlConnection")));


// Dapper DB Context
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Database>();

//Repositories
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

//Unit of work
builder.Services.AddScoped<DbConnection>(provider =>
    new SqlConnection(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Services
builder.Services.AddScoped<IAlbumService, AlbumService>();

var app = builder.Build();

//Run DB Migrations
app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();