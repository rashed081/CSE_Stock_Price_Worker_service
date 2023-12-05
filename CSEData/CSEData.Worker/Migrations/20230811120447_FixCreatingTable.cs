using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSEData.Worker.Migrations
{
    /// <inheritdoc />
    public partial class FixCreatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Companies_Companyid",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "Companyid",
                table: "Prices",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_Companyid",
                table: "Prices",
                newName: "IX_Prices_companyId");

            migrationBuilder.AlterColumn<int>(
                name: "companyId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Companies_companyId",
                table: "Prices",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Companies_companyId",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Prices",
                newName: "Companyid");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_companyId",
                table: "Prices",
                newName: "IX_Prices_Companyid");

            migrationBuilder.AlterColumn<int>(
                name: "Companyid",
                table: "Prices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Companies_Companyid",
                table: "Prices",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "id");
        }
    }
}
