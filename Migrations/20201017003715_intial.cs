using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandWebApi.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("a791d1e5-9ec5-427c-b1da-5152fe3b2798"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("4035ab45-7b8e-41ff-a181-d8f81b6ca633"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Gnus N Roses" },
                    { new Guid("515f0e4b-ec42-476d-b408-e28579352088"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("f51e023d-97de-44ec-bbfb-ff24ef39bdf0"), new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("68ffce07-ae53-43cb-a8a8-260f95ca4743"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("664e3727-fe08-4bba-84a0-918b522443b3"), new Guid("a791d1e5-9ec5-427c-b1da-5152fe3b2798"), "One of the best heavy metal album ever", "Master Of Poppets" },
                    { new Guid("381aa698-3a67-4322-8c4f-e8fa472fdf9d"), new Guid("4035ab45-7b8e-41ff-a181-d8f81b6ca633"), "Amazing Rock album with raw sound", "Appetite for Destruction" },
                    { new Guid("f4393aad-4c77-4a05-8b47-8f84d8841822"), new Guid("515f0e4b-ec42-476d-b408-e28579352088"), "Very groovy album", "Waterloo" },
                    { new Guid("5945a30d-0c8e-4c19-b51f-6375f0b56b46"), new Guid("f51e023d-97de-44ec-bbfb-ff24ef39bdf0"), "Arguably one of the best albums bu Oasis", "Be Here Now" },
                    { new Guid("1754795b-b366-4e24-abc9-ab10bb60455d"), new Guid("68ffce07-ae53-43cb-a8a8-260f95ca4743"), "Awesome Debut album by A-ha", "Huning High and Low " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
