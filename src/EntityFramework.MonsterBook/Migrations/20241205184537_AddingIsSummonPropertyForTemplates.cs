using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.MonsterBook.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsSummonPropertyForTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSummon",
                table: "NpcTemplate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SummonType",
                table: "NpcTemplate",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NpcTemplate_SummonType",
                table: "NpcTemplate",
                column: "SummonType",
                unique: true,
                filter: "[IsSummon] = 1");

            migrationBuilder.AddCheckConstraint(
                name: "CK_IsSummon_SummonType",
                table: "NpcTemplate",
                sql: "([IsSummon] = 0 AND [SummonType] IS NULL) OR ([IsSummon] = 1 AND [SummonType] IS NOT NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NpcTemplate_SummonType",
                table: "NpcTemplate");

            migrationBuilder.DropCheckConstraint(
                name: "CK_IsSummon_SummonType",
                table: "NpcTemplate");

            migrationBuilder.DropColumn(
                name: "IsSummon",
                table: "NpcTemplate");

            migrationBuilder.DropColumn(
                name: "SummonType",
                table: "NpcTemplate");
        }
    }
}
