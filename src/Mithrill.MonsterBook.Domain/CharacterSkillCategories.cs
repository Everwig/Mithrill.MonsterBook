using Mithrill.MonsterBook.Domain.Entities;
using Mithrill.MonsterBook.Domain.ValueObjects;

namespace Mithrill.MonsterBook.Domain;

public class CharacterSkillCategories
{
    public SkillCategory Primary { get; set; }
    public SkillCategory FirstSecondary { get; set; }
    public SkillCategory SecondSecondary { get; set; }
    public SkillCategory Tertiary { get; set; }

    public int NpcTemplateId { get; set; }
    public NpcTemplate NpcTemplate { get; set; }
}