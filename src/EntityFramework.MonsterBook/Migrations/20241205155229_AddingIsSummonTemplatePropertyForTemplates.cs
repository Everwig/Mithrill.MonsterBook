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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSummon",
                table: "NpcTemplate");
        }
    }
}
