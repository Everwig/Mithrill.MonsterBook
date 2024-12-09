using FluentValidation;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public sealed class ValidateNpcTemplateQueryValidator : AbstractValidator<ValidateNpcTemplateQuery>
{
    public ValidateNpcTemplateQueryValidator(ITemplateValidatorService templateValidatorService)
    {
        RuleFor(query => query.NpcTemplate)
            .SetValidator(query => new NpcTemplateValidator(templateValidatorService, query.NpcTemplate.IsSummon));
    }

    public sealed class NpcTemplateValidator : AbstractValidator<NpcTemplate>
    {
        public NpcTemplateValidator() { }

        public NpcTemplateValidator(ITemplateValidatorService templateValidatorService, bool isSummon)
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
            RuleFor(npcTemplate => npcTemplate.SkillCategories).SkillCategoriesValidation();
            RuleFor(npcTemplate => npcTemplate.ArcanumRanks).ArcanumRanksValidation(templateValidatorService);
            RuleFor(npcTemplate => npcTemplate.IsUndead).IsUndeadValidation();
            RuleFor(npcTemplate => npcTemplate.IsSummon).IsSummonValidation();
            RuleFor(npcTemplate => npcTemplate.SummonType).SummonTypeValidation();

            RuleFor(npcTemplate => npcTemplate.Merits).ForEach(merit => merit.MeritValidation(templateValidatorService));
            RuleFor(npcTemplate => npcTemplate.Flaws).ForEach(flaw => flaw.FlawValidation(templateValidatorService));

            RuleFor(npcTemplate => npcTemplate.Skills)
                .ForEach(skills => skills.SetValidator(new SkillValidator(templateValidatorService, isSummon)));

            RuleFor(npcTemplate => npcTemplate.Armors)
                .ForEach(armor => armor.SetValidator(new ArmorValidator(templateValidatorService)));

            RuleFor(npcTemplate => npcTemplate.Weapons)
                .ForEach(weapon => weapon.SetValidator(new WeaponValidator(templateValidatorService)));
        }

        public sealed class SkillValidator : AbstractValidator<Skill>
        {
            public SkillValidator() { }

            public SkillValidator(ITemplateValidatorService templateValidatorService, bool isSummon)
            {
                RuleFor(skill => skill.Id).SkillIdValidation(templateValidatorService);
                RuleFor(skill => skill.GuaranteedSuccesses).GuaranteedSuccessValidation();
                RuleFor(skill => skill.MaxLevel).LevelValidation(isSummon);
                RuleFor(skill => skill.MinLevel).LevelValidation(isSummon);
                RuleFor(skill => skill).LevelValidation();
            }
        }

        public sealed class ArmorValidator : AbstractValidator<Armor>
        {
            public ArmorValidator(ITemplateValidatorService templateValidatorService)
            {
                RuleFor(armor => armor.Id).IsValidArmorId(templateValidatorService);
                RuleFor(armor => armor.Material).EnumValidation();
                RuleFor(armor => armor.AdditionalArmorClass).AdditionalArmorClassValidation();
                RuleFor(armor => armor.AdditionalMovementInhibitoryFactor).AdditionalMovementInhibitoryFactorValidation();
            }
        }

        public sealed class WeaponValidator : AbstractValidator<Weapon>
        {
            public WeaponValidator(ITemplateValidatorService templateValidatorService)
            {
                RuleFor(weapon => weapon.Id).IsValidWeaponId(templateValidatorService);
                RuleFor(weapon => weapon.Material).EnumValidation();
                RuleFor(weapon => weapon.AdditionalAttackModifier).AdditionalModifierValidation();
                RuleFor(weapon => weapon.AdditionalDefenseModifier).AdditionalModifierValidation();
                RuleFor(weapon => weapon.AdditionalInitiativeModifier).AdditionalModifierValidation();
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