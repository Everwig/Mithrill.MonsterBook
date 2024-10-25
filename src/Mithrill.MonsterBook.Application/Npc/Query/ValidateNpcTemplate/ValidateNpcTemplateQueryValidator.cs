using FluentValidation;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate
{
    public sealed class ValidateNpcTemplateQueryValidator : AbstractValidator<ValidateNpcTemplateQuery>
    {
        public ValidateNpcTemplateQueryValidator(ITemplateValidatorService templateValidatorService)
        {
            RuleFor(query => query.NpcTemplate)
                .SetValidator(new NpcTemplateValidator(templateValidatorService));
        }

        public sealed class NpcTemplateValidator : AbstractValidator<NpcTemplate>
        {
            public NpcTemplateValidator(ITemplateValidatorService templateValidatorService)
            {
                RuleSet(ValidationMode.Create.ToString(), () => RuleFor(npcTemplate => npcTemplate.Id).Null());
                RuleSet(ValidationMode.Edit.ToString(), () => RuleFor(npcTemplate => npcTemplate.Id)
                    .NpcTemplateIdValidation(templateValidatorService));

                RuleFor(npcTemplate => npcTemplate.StrengthMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.StrengthMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.VitalityMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.VitalityMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.BodyMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.BodyMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.AgilityMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.AgilityMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.DexterityMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.DexterityMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.IntelligenceMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.IntelligenceMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.WillpowerMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.WillpowerMin).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.EmotionMax).AttributeValidation();
                RuleFor(npcTemplate => npcTemplate.EmotionMin).AttributeValidation();

                RuleFor(npcTemplate => npcTemplate.KarmaMax).ZeroableValidation();
                RuleFor(npcTemplate => npcTemplate.KarmaMin).ZeroableValidation();
                RuleFor(npcTemplate => npcTemplate.DamageReductionMax).ZeroableValidation();
                RuleFor(npcTemplate => npcTemplate.DamageReductionMin).ZeroableValidation();

                RuleFor(npcTemplate => npcTemplate.Name).NameValidation();

                RuleFor(npcTemplate => npcTemplate.Race).EnumValidation();
                RuleFor(npcTemplate => npcTemplate.Difficulty).EnumValidation();

                RuleFor(npcTemplate => npcTemplate.SkillCategories).UniqueSkillCategoriesValidation();
                RuleFor(npcTemplate => npcTemplate.SkillCategories).NullSkillCategories()
                    .SetValidator(new SkillCategoriesValidator())
                    .When(template => template.SkillCategories is not null, ApplyConditionTo.CurrentValidator);

                RuleFor(npcTemplate => npcTemplate.Merits).MeritValidation(templateValidatorService);
                RuleFor(npcTemplate => npcTemplate.Flaws).FlawValidation(templateValidatorService);

                RuleFor(npcTemplate => npcTemplate.Skills).SkillValidation(templateValidatorService)
                    .ForEach(skills => skills.SetValidator(new SkillValidator(templateValidatorService)));

                RuleFor(npcTemplate => npcTemplate.Armors)
                    .ForEach(armor => armor.SetValidator(new ArmorValidator(templateValidatorService)));

                RuleFor(npcTemplate => npcTemplate.Weapons)
                    .ForEach(weapon => weapon.SetValidator(new WeaponValidator(templateValidatorService)));
            }

            public sealed class SkillValidator : AbstractValidator<Skill>
            {
                public SkillValidator(ITemplateValidatorService templateValidatorService)
                {
                    RuleFor(skill => skill.Id).SkillIdValidation(templateValidatorService);
                    RuleFor(skill => skill.GuaranteedSuccesses).GuaranteedSuccessValidation();
                    RuleFor(skill => skill.MaxLevel).LevelValidation();
                    RuleFor(skill => skill.MinLevel).LevelValidation();
                }
            }

            public sealed class SkillCategoriesValidator : AbstractValidator<SkillCategories>
            {
                public SkillCategoriesValidator()
                {
                    RuleFor(skillCategory => skillCategory.Primary).EnumValidation();
                    RuleFor(skillCategory => skillCategory.FirstSecondary).EnumValidation();
                    RuleFor(skillCategory => skillCategory.SecondSecondary).EnumValidation();
                    RuleFor(skillCategory => skillCategory.Tertiary).EnumValidation();
                }
            }

            public sealed class ArmorValidator : AbstractValidator<Armor>
            {
                public ArmorValidator(ITemplateValidatorService templateValidatorService)
                {
                    RuleFor(armor => armor.Id).IsValidArmorId(templateValidatorService);
                    RuleFor(armor => armor.Material).EnumValidation();
                    RuleFor(armor => armor.AdditionalArmorClass).AdditionalValueValidation();
                    RuleFor(armor => armor.AdditionalMovementInhibitoryFactor).AdditionalMgtValueValidation();
                }
            }

            public sealed class WeaponValidator : AbstractValidator<Weapon>
            {
                public WeaponValidator(ITemplateValidatorService templateValidatorService)
                {
                    RuleFor(weapon => weapon.Id).IsValidWeaponId(templateValidatorService);
                    RuleFor(weapon => weapon.Material).EnumValidation();
                    RuleFor(weapon => weapon.AdditionalAttackModifier).AdditionalValueValidation();
                    RuleFor(weapon => weapon.AdditionalDefenseModifier).AdditionalValueValidation();
                    RuleFor(weapon => weapon.AdditionalInitiativeModifier).AdditionalValueValidation();
                    RuleFor(weapon => weapon.AdditionalAttackTypes)
                        .ForEach(attackType => attackType.SetValidator(new AttackTypeValidator()));
                }

                public sealed class AttackTypeValidator : AbstractValidator<AttackType>
                {
                    public AttackTypeValidator()
                    {
                        RuleFor(attackType => attackType.DamageType).EnumValidation();
                        RuleFor(attackType => attackType.GuaranteedDamage).GuaranteedDamageValidation();
                        RuleFor(attackType => attackType.NumberOfDices).NumberOfDicesValidation();
                    }
                }
            }
        }
    }
}