using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_RentProcess_and_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentCars_Cars_CarId",
                table: "RentCars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentCars_Locations_LocationId",
                table: "RentCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentCars",
                table: "RentCars");

            migrationBuilder.RenameTable(
                name: "RentCars",
                newName: "RentCar");

            migrationBuilder.RenameIndex(
                name: "IX_RentCars_LocationId",
                table: "RentCar",
                newName: "IX_RentCar_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_RentCars_CarId",
                table: "RentCar",
                newName: "IX_RentCar_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentCar",
                table: "RentCar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PickUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickUpLocation = table.Column<int>(type: "int", nullable: false),
                    DropOffLocation = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DropOffDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentProcess_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentProcess_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentProcess_CarId",
                table: "RentProcess",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentProcess_CustomerId",
                table: "RentProcess",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentCar_Cars_CarId",
                table: "RentCar",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentCar_Locations_LocationId",
                table: "RentCar",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentCar_Cars_CarId",
                table: "RentCar");

            migrationBuilder.DropForeignKey(
                name: "FK_RentCar_Locations_LocationId",
                table: "RentCar");

            migrationBuilder.DropTable(
                name: "RentProcess");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentCar",
                table: "RentCar");

            migrationBuilder.RenameTable(
                name: "RentCar",
                newName: "RentCars");

            migrationBuilder.RenameIndex(
                name: "IX_RentCar_LocationId",
                table: "RentCars",
                newName: "IX_RentCars_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_RentCar_CarId",
                table: "RentCars",
                newName: "IX_RentCars_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentCars",
                table: "RentCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentCars_Cars_CarId",
                table: "RentCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentCars_Locations_LocationId",
                table: "RentCars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
