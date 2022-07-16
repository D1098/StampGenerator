using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningP.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stamps",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StampGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stamps", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StampGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stamps",
                columns: new[] { "Key", "Reason", "StampGuid", "Time" },
                values: new object[] { new Guid("72a0bad6-e871-4687-b62c-955a9f2bac7c"), "Testing", new Guid("b375d261-a40f-4277-9e95-abd305f5ebfd"), new DateTime(2022, 7, 16, 11, 55, 54, 50, DateTimeKind.Local).AddTicks(4992) });

            migrationBuilder.InsertData(
                table: "Stamps",
                columns: new[] { "Key", "Reason", "StampGuid", "Time" },
                values: new object[] { new Guid("8caa015a-140b-47f6-84cc-029f6b204922"), "Reason", new Guid("f02975d1-51e8-4a21-902b-55b819497321"), new DateTime(2022, 7, 16, 11, 55, 54, 50, DateTimeKind.Local).AddTicks(5010) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stamps");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
