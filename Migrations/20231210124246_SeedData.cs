using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb2.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "PlantName" },
                values: new object[] { 1, "Rose" });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instruction", "PlantId" },
                values: new object[] { 1, "Water frequently", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);
        }
    }
}
