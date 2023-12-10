using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb2.Migrations
{
    /// <inheritdoc />
    public partial class InstructionsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instruction", "PlantId" },
                values: new object[] { 2, "Beware of the pointy thorns ", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 2);
        }
    }
}
