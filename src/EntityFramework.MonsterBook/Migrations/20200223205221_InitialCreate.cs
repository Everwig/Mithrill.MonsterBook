using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.MonsterBook.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StrengthMax = table.Column<int>(nullable: false),
                    StrengthMin = table.Column<int>(nullable: false),
                    VitalityMax = table.Column<int>(nullable: false),
                    VitalityMin = table.Column<int>(nullable: false),
                    BodyMax = table.Column<int>(nullable: false),
                    BodyMin = table.Column<int>(nullable: false),
                    SpeedMax = table.Column<int>(nullable: false),
                    SpeedMin = table.Column<int>(nullable: false),
                    AgilityMax = table.Column<int>(nullable: false),
                    AgilityMin = table.Column<int>(nullable: false),
                    IntelligenceMax = table.Column<int>(nullable: false),
                    IntelligenceMin = table.Column<int>(nullable: false),
                    WillpowerMax = table.Column<int>(nullable: false),
                    WillpowerMin = table.Column<int>(nullable: false),
                    SensationMax = table.Column<int>(nullable: false),
                    SensationMin = table.Column<int>(nullable: false),
                    DamageReductionMax = table.Column<int>(nullable: false),
                    DamageReductionMin = table.Column<int>(nullable: false),
                    Karma = table.Column<int>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreatureMerit",
                columns: table => new
                {
                    MonsterId = table.Column<int>(nullable: false),
                    MeritId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterMerit", x => new { x.MonsterId, x.MeritId });
                    table.ForeignKey(
                        name: "FK_MonsterMerit_Merit_MeritId",
                        column: x => x.MeritId,
                        principalTable: "Merit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterMerit_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSkill",
                columns: table => new
                {
                    MonsterId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterSkill", x => new { x.MonsterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MonsterSkill_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttackType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NumberOfDice = table.Column<int>(nullable: false),
                    ExtraDamage = table.Column<int>(nullable: false),
                    ExtraDamageType = table.Column<string>(nullable: true),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttackType_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureWeapon",
                columns: table => new
                {
                    MonsterId = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterWeapon", x => new { x.MonsterId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_MonsterWeapon_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterWeapon_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttackType_WeaponId",
                table: "AttackType",
                column: "WeaponId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMerit_MeritId",
                table: "CreatureMerit",
                column: "MeritId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSkill_SkillId",
                table: "CreatureSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterWeapon_WeaponId",
                table: "CreatureWeapon",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackType");

            migrationBuilder.DropTable(
                name: "CreatureMerit");

            migrationBuilder.DropTable(
                name: "CreatureSkill");

            migrationBuilder.DropTable(
                name: "CreatureWeapon");

            migrationBuilder.DropTable(
                name: "Merit");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
