using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace MvcNet5.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Bio = table.Column<string>(isNullable: true),
                    Blog = table.Column<string>(isNullable: true),
                    Email = table.Column<string>(isNullable: true),
                    FirstName = table.Column<string>(isNullable: false),
                    LastName = table.Column<string>(isNullable: false),
                    MobilePhone = table.Column<string>(isNullable: true),
                    PhotoURL = table.Column<string>(isNullable: true),
                    Specialization = table.Column<string>(isNullable: true),
                    Twitter = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Speaker");
        }
    }
}
