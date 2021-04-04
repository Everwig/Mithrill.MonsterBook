using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.MonsterBook.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AgilityMax = table.Column<int>(nullable: false),
                    AgilityMin = table.Column<int>(nullable: false),
                    DexterityMax = table.Column<int>(nullable: false),
                    DexterityMin = table.Column<int>(nullable: false),
                    IntelligenceMax = table.Column<int>(nullable: false),
                    IntelligenceMin = table.Column<int>(nullable: false),
                    WillpowerMax = table.Column<int>(nullable: false),
                    WillpowerMin = table.Column<int>(nullable: false),
                    EmotionMax = table.Column<int>(nullable: false),
                    EmotionMin = table.Column<int>(nullable: false),
                    DamageReductionMax = table.Column<int>(nullable: false),
                    DamageReductionMin = table.Column<int>(nullable: false),
                    SkillLevelMax = table.Column<int>(nullable: false),
                    SkillLevelMin = table.Column<int>(nullable: false),
                    Karma = table.Column<int>(nullable: false),
                    IsUndead = table.Column<bool>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flaw",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flaw", x => x.Id);
                });

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
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
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
                name: "CreatureSkillCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Primary = table.Column<int>(nullable: false),
                    FirstSecondary = table.Column<int>(nullable: false),
                    SecondSecondary = table.Column<int>(nullable: false),
                    Tertiary = table.Column<int>(nullable: false),
                    CreatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSkillCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSkillCategories_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureFlaw",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false),
                    FlawId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureFlaw", x => new { x.CreatureId, x.FlawId });
                    table.ForeignKey(
                        name: "FK_CreatureFlaw_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureFlaw_Flaw_FlawId",
                        column: x => x.FlawId,
                        principalTable: "Flaw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureMerit",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false),
                    MeritId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureMerit", x => new { x.CreatureId, x.MeritId });
                    table.ForeignKey(
                        name: "FK_CreatureMerit_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureMerit_Merit_MeritId",
                        column: x => x.MeritId,
                        principalTable: "Merit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSkill",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSkill", x => new { x.CreatureId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CreatureSkill_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureSkill_Skill_SkillId",
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
                    CreatureId = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureWeapon", x => new { x.CreatureId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_CreatureWeapon_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureWeapon_Weapon_WeaponId",
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
                name: "IX_CreatureFlaw_FlawId",
                table: "CreatureFlaw",
                column: "FlawId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureMerit_MeritId",
                table: "CreatureMerit",
                column: "MeritId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSkill_SkillId",
                table: "CreatureSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSkillCategories_CreatureId",
                table: "CreatureSkillCategories",
                column: "CreatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreatureWeapon_WeaponId",
                table: "CreatureWeapon",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackType");

            migrationBuilder.DropTable(
                name: "CreatureFlaw");

            migrationBuilder.DropTable(
                name: "CreatureMerit");

            migrationBuilder.DropTable(
                name: "CreatureSkill");

            migrationBuilder.DropTable(
                name: "CreatureSkillCategories");

            migrationBuilder.DropTable(
                name: "CreatureWeapon");

            migrationBuilder.DropTable(
                name: "Flaw");

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
