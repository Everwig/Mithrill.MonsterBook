using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.MonsterBook.Migrations
{
    /// <inheritdoc />
    public partial class CharacterSkillCategoriesTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSkillCategories",
                table: "CharacterSkillCategories");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSkillCategories_NpcTemplateId",
                table: "CharacterSkillCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CharacterSkillCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSkillCategories",
                table: "CharacterSkillCategories",
                column: "NpcTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSkillCategories",
                table: "CharacterSkillCategories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CharacterSkillCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSkillCategories",
                table: "CharacterSkillCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkillCategories_NpcTemplateId",
                table: "CharacterSkillCategories",
                column: "NpcTemplateId",
                unique: true);
        }
    }
}
