using FwksLabs.AppService.Core.Resources.Common.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FwksLabs.AppService.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<NameModel>(type: "jsonb", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<PhoneNumberModel>(type: "jsonb", nullable: false),
                    Address = table.Column<AddressModel>(type: "jsonb", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "App",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UK_Customers",
                schema: "App",
                table: "Customers",
                column: "UniqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "App",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UK_Orders",
                schema: "App",
                table: "Orders",
                column: "UniqueId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "App");
        }
    }
}
