using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma;

public class Skill : IMapFrom<Domain.Skill>
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int GuaranteedSuccesses { get; set; }
    public SkillCategory Category { get; set; }
}