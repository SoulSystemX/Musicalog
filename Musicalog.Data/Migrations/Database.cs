﻿using Dapper;
using Musicalog.Data.Context;

namespace Musicalog.Data.Migrations;

public class Database(DapperContext context)
{
    public void CreateDatabase(string dbName)
    {
        var query = "SELECT * FROM sys.databases WHERE name = @name";
        var parameters = new DynamicParameters();
        parameters.Add("name", dbName);
        using (var connection = context.CreateMasterConnection())
        {
            var records = connection.Query(query, parameters);
            if (!records.Any())
                connection.Execute($"CREATE DATABASE {dbName}");
        }
    }
}