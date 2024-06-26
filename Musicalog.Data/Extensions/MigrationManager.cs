﻿using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Musicalog.Data.Migrations;

namespace Musicalog.Data.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            databaseService.CreateDatabase("musicalog");

            migrationService.ListMigrations();
            migrationService.MigrateUp();
        }

        return host;
    }
}