using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.MonsterBook.Migrations
{
    /// <inheritdoc />
    public partial class GetAllCreatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttackType_Weapon_WeaponId",
                table: "AttackType");

            migrationBuilder.DropIndex(
                name: "IX_AttackType_WeaponId",
                table: "AttackType");

            migrationBuilder.DropColumn(
                name: "ExtraDamageType",
                table: "AttackType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AttackType");

            migrationBuilder.RenameColumn(
                name: "WeaponId",
                table: "AttackType",
                newName: "NumberOfDices");

            migrationBuilder.RenameColumn(
                name: "NumberOfDice",
                table: "AttackType",
                newName: "GuaranteedDamage");

            migrationBuilder.RenameColumn(
                name: "ExtraDamage",
                table: "AttackType",
                newName: "DamageType");

            migrationBuilder.AddColumn<int>(
                name: "BaseAttackModifier",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseAttackTypeId",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseDefenseModifier",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseInitiativeModifier",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalAttackModifier",
                table: "CreatureWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalDefenseModifier",
                table: "CreatureWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalInitiativeModifier",
                table: "CreatureWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOptional",
                table: "CreatureWeapon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Material",
                table: "CreatureWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOptional",
                table: "CreatureSkill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOptional",
                table: "CreatureMerit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOptional",
                table: "CreatureFlaw",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Race",
                table: "Creature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameHu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseArmorClass = table.Column<int>(type: "int", nullable: false),
                    BaseMovementInhibitoryFactor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreatureWeaponAttackType",
                columns: table => new
                {
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    AttackTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureWeaponAttackType", x => new { x.AttackTypeId, x.CreatureId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_CreatureWeaponAttackType_AttackType_AttackTypeId",
                        column: x => x.AttackTypeId,
                        principalTable: "AttackType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureWeaponAttackType_CreatureWeapon_CreatureId_WeaponId",
                        columns: x => new { x.CreatureId, x.WeaponId },
                        principalTable: "CreatureWeapon",
                        principalColumns: new[] { "CreatureId", "WeaponId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureArmor",
                columns: table => new
                {
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    ArmorId = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    AdditionalArmorClass = table.Column<int>(type: "int", nullable: false),
                    AdditionalMovementInhibitoryFactor = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureArmor", x => new { x.CreatureId, x.ArmorId });
                    table.ForeignKey(
                        name: "FK_CreatureArmor_Armor_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureArmor_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_BaseAttackTypeId",
                table: "Weapon",
                column: "BaseAttackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Armor_Name_NameHu",
                table: "Armor",
                columns: new[] { "Name", "NameHu" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [NameHu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureArmor_ArmorId",
                table: "CreatureArmor",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureWeaponAttackType_CreatureId_WeaponId",
                table: "CreatureWeaponAttackType",
                columns: new[] { "CreatureId", "WeaponId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_AttackType_BaseAttackTypeId",
                table: "Weapon",
                column: "BaseAttackTypeId",
                principalTable: "AttackType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_AttackType_BaseAttackTypeId",
                table: "Weapon");

            migrationBuilder.DropTable(
                name: "CreatureArmor");

            migrationBuilder.DropTable(
                name: "CreatureWeaponAttackType");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropIndex(
                name: "IX_Weapon_BaseAttackTypeId",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "BaseAttackModifier",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "BaseAttackTypeId",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "BaseDefenseModifier",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "BaseInitiativeModifier",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "AdditionalAttackModifier",
                table: "CreatureWeapon");

            migrationBuilder.DropColumn(
                name: "AdditionalDefenseModifier",
                table: "CreatureWeapon");

            migrationBuilder.DropColumn(
                name: "AdditionalInitiativeModifier",
                table: "CreatureWeapon");

            migrationBuilder.DropColumn(
                name: "IsOptional",
                table: "CreatureWeapon");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "CreatureWeapon");

            migrationBuilder.DropColumn(
                name: "IsOptional",
                table: "CreatureSkill");

            migrationBuilder.DropColumn(
                name: "IsOptional",
                table: "CreatureMerit");

            migrationBuilder.DropColumn(
                name: "IsOptional",
                table: "CreatureFlaw");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Creature");

            migrationBuilder.RenameColumn(
                name: "NumberOfDices",
                table: "AttackType",
                newName: "WeaponId");

            migrationBuilder.RenameColumn(
                name: "GuaranteedDamage",
                table: "AttackType",
                newName: "NumberOfDice");

            migrationBuilder.RenameColumn(
                name: "DamageType",
                table: "AttackType",
                newName: "ExtraDamage");

            migrationBuilder.AddColumn<string>(
                name: "ExtraDamageType",
                table: "AttackType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AttackType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttackType_WeaponId",
                table: "AttackType",
                column: "WeaponId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttackType_Weapon_WeaponId",
                table: "AttackType",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
