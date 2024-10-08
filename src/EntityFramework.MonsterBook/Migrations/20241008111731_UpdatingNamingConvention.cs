using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.MonsterBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingNamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureArmor");

            migrationBuilder.DropTable(
                name: "CreatureFlaw");

            migrationBuilder.DropTable(
                name: "CreatureMerit");

            migrationBuilder.DropTable(
                name: "CreatureSkill");

            migrationBuilder.DropTable(
                name: "CreatureSkillCategories");

            migrationBuilder.DropTable(
                name: "CreatureWeaponAttackType");

            migrationBuilder.DropTable(
                name: "CreatureWeapon");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.CreateTable(
                name: "NpcTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameHu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrengthMax = table.Column<int>(type: "int", nullable: false),
                    StrengthMin = table.Column<int>(type: "int", nullable: false),
                    VitalityMax = table.Column<int>(type: "int", nullable: false),
                    VitalityMin = table.Column<int>(type: "int", nullable: false),
                    BodyMax = table.Column<int>(type: "int", nullable: false),
                    BodyMin = table.Column<int>(type: "int", nullable: false),
                    AgilityMax = table.Column<int>(type: "int", nullable: false),
                    AgilityMin = table.Column<int>(type: "int", nullable: false),
                    DexterityMax = table.Column<int>(type: "int", nullable: false),
                    DexterityMin = table.Column<int>(type: "int", nullable: false),
                    IntelligenceMax = table.Column<int>(type: "int", nullable: false),
                    IntelligenceMin = table.Column<int>(type: "int", nullable: false),
                    WillpowerMax = table.Column<int>(type: "int", nullable: false),
                    WillpowerMin = table.Column<int>(type: "int", nullable: false),
                    EmotionMax = table.Column<int>(type: "int", nullable: false),
                    EmotionMin = table.Column<int>(type: "int", nullable: false),
                    DamageReductionMax = table.Column<int>(type: "int", nullable: false),
                    DamageReductionMin = table.Column<int>(type: "int", nullable: false),
                    KarmaMax = table.Column<int>(type: "int", nullable: false),
                    KarmaMin = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NpcTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterArmor",
                columns: table => new
                {
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false),
                    ArmorId = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    AdditionalArmorClass = table.Column<int>(type: "int", nullable: false),
                    AdditionalMovementInhibitoryFactor = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterArmor", x => new { x.NpcTemplateId, x.ArmorId });
                    table.ForeignKey(
                        name: "FK_CharacterArmor_Armor_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterArmor_NpcTemplate_NpcTemplateId",
                        column: x => x.NpcTemplateId,
                        principalTable: "NpcTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFlaw",
                columns: table => new
                {
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false),
                    FlawId = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFlaw", x => new { x.NpcTemplateId, x.FlawId });
                    table.ForeignKey(
                        name: "FK_CharacterFlaw_Flaw_FlawId",
                        column: x => x.FlawId,
                        principalTable: "Flaw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFlaw_NpcTemplate_NpcTemplateId",
                        column: x => x.NpcTemplateId,
                        principalTable: "NpcTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMerit",
                columns: table => new
                {
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false),
                    MeritId = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMerit", x => new { x.NpcTemplateId, x.MeritId });
                    table.ForeignKey(
                        name: "FK_CharacterMerit_Merit_MeritId",
                        column: x => x.MeritId,
                        principalTable: "Merit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMerit_NpcTemplate_NpcTemplateId",
                        column: x => x.NpcTemplateId,
                        principalTable: "NpcTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkill",
                columns: table => new
                {
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillLevelMin = table.Column<int>(type: "int", nullable: false),
                    SkillLevelMax = table.Column<int>(type: "int", nullable: false),
                    GuaranteedSuccesses = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkill", x => new { x.NpcTemplateId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkill_NpcTemplate_NpcTemplateId",
                        column: x => x.NpcTemplateId,
                        principalTable: "NpcTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkillCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Primary = table.Column<int>(type: "int", nullable: false),
                    FirstSecondary = table.Column<int>(type: "int", nullable: false),
                    SecondSecondary = table.Column<int>(type: "int", nullable: false),
                    Tertiary = table.Column<int>(type: "int", nullable: false),
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkillCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSkillCategories_NpcTemplate_NpcTemplateId",
                        column: x => x.NpcTemplateId,
                        principalTable: "NpcTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterWeapon",
                columns: table => new
                {
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    AdditionalAttackModifier = table.Column<int>(type: "int", nullable: false),
                    AdditionalDefenseModifier = table.Column<int>(type: "int", nullable: false),
                    AdditionalInitiativeModifier = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterWeapon", x => new { x.NpcTemplateId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_NpcTemplate_NpcTemplateId",
                        column: x => x.NpcTemplateId,
                        principalTable: "NpcTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterWeaponAttackType",
                columns: table => new
                {
                    NpcTemplateId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    AttackTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterWeaponAttackType", x => new { x.AttackTypeId, x.NpcTemplateId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterWeaponAttackType_AttackType_AttackTypeId",
                        column: x => x.AttackTypeId,
                        principalTable: "AttackType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterWeaponAttackType_CharacterWeapon_NpcTemplateId_WeaponId",
                        columns: x => new { x.NpcTemplateId, x.WeaponId },
                        principalTable: "CharacterWeapon",
                        principalColumns: new[] { "NpcTemplateId", "WeaponId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterArmor_ArmorId",
                table: "CharacterArmor",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFlaw_FlawId",
                table: "CharacterFlaw",
                column: "FlawId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMerit_MeritId",
                table: "CharacterMerit",
                column: "MeritId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkill_SkillId",
                table: "CharacterSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkillCategories_NpcTemplateId",
                table: "CharacterSkillCategories",
                column: "NpcTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterWeapon_WeaponId",
                table: "CharacterWeapon",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterWeaponAttackType_NpcTemplateId_WeaponId",
                table: "CharacterWeaponAttackType",
                columns: new[] { "NpcTemplateId", "WeaponId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterArmor");

            migrationBuilder.DropTable(
                name: "CharacterFlaw");

            migrationBuilder.DropTable(
                name: "CharacterMerit");

            migrationBuilder.DropTable(
                name: "CharacterSkill");

            migrationBuilder.DropTable(
                name: "CharacterSkillCategories");

            migrationBuilder.DropTable(
                name: "CharacterWeaponAttackType");

            migrationBuilder.DropTable(
                name: "CharacterWeapon");

            migrationBuilder.DropTable(
                name: "NpcTemplate");

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgilityMax = table.Column<int>(type: "int", nullable: false),
                    AgilityMin = table.Column<int>(type: "int", nullable: false),
                    BodyMax = table.Column<int>(type: "int", nullable: false),
                    BodyMin = table.Column<int>(type: "int", nullable: false),
                    DamageReductionMax = table.Column<int>(type: "int", nullable: false),
                    DamageReductionMin = table.Column<int>(type: "int", nullable: false),
                    DexterityMax = table.Column<int>(type: "int", nullable: false),
                    DexterityMin = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    EmotionMax = table.Column<int>(type: "int", nullable: false),
                    EmotionMin = table.Column<int>(type: "int", nullable: false),
                    IntelligenceMax = table.Column<int>(type: "int", nullable: false),
                    IntelligenceMin = table.Column<int>(type: "int", nullable: false),
                    IsUndead = table.Column<bool>(type: "bit", nullable: false),
                    KarmaMax = table.Column<int>(type: "int", nullable: false),
                    KarmaMin = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameHu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<int>(type: "int", nullable: false),
                    StrengthMax = table.Column<int>(type: "int", nullable: false),
                    StrengthMin = table.Column<int>(type: "int", nullable: false),
                    VitalityMax = table.Column<int>(type: "int", nullable: false),
                    VitalityMin = table.Column<int>(type: "int", nullable: false),
                    WillpowerMax = table.Column<int>(type: "int", nullable: false),
                    WillpowerMin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreatureArmor",
                columns: table => new
                {
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    ArmorId = table.Column<int>(type: "int", nullable: false),
                    AdditionalArmorClass = table.Column<int>(type: "int", nullable: false),
                    AdditionalMovementInhibitoryFactor = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CreatureFlaw",
                columns: table => new
                {
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    FlawId = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
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
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    MeritId = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false)
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
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    GuaranteedSuccesses = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    SkillLevelMax = table.Column<int>(type: "int", nullable: false),
                    SkillLevelMin = table.Column<int>(type: "int", nullable: false)
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
                name: "CreatureSkillCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    FirstSecondary = table.Column<int>(type: "int", nullable: false),
                    Primary = table.Column<int>(type: "int", nullable: false),
                    SecondSecondary = table.Column<int>(type: "int", nullable: false),
                    Tertiary = table.Column<int>(type: "int", nullable: false)
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
                name: "CreatureWeapon",
                columns: table => new
                {
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    AdditionalAttackModifier = table.Column<int>(type: "int", nullable: false),
                    AdditionalDefenseModifier = table.Column<int>(type: "int", nullable: false),
                    AdditionalInitiativeModifier = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CreatureWeaponAttackType",
                columns: table => new
                {
                    AttackTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CreatureArmor_ArmorId",
                table: "CreatureArmor",
                column: "ArmorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CreatureWeaponAttackType_CreatureId_WeaponId",
                table: "CreatureWeaponAttackType",
                columns: new[] { "CreatureId", "WeaponId" });
        }
    }
}
