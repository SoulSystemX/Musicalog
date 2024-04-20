using FluentMigrator;
using Musicalog.Data.Entities;
using Musicalog.Data.Models;

namespace Musicalog.Data.Migrations;

[Migration(0001)]
public class InitialTables_0001 : Migration
{
     public override void Down()
     {
         Delete.FromTable("Album")
             .Row(new Album
             {
                 Artist = "Linkin Park",
                 Name = "Meteora",
                 Genre = "Rock",
                 ReleaseDate = new DateTime(2003, 03,25)
             });
     }
     
     public override void Up()
     { 
         Create.Table("Album")
             .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
             .WithColumn("Artist").AsString().NotNullable()
             .WithColumn("Name").AsString().NotNullable()
             .WithColumn("Genre").AsString()
             .WithColumn("ReleaseDate").AsDate().NotNullable();
         for (int i = 0; i < 20; i++)
         {
             Insert.IntoTable("Album")
                 .Row(new
                 {
                     Artist = "Linkin Park",
                     Name = "Meteora",
                     Genre = "Rock",
                     ReleaseDate = new DateTime(2003, 03, 25)
                 });
         }
     }
 }