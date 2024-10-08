using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Skills.Query.GetAllForNpcTemplates;

public class Skill : IMapFrom<MonsterBook.Domain.Skill>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Attribute Attribute1 { get; set; }
    public Attribute Attribute2 { get; set; }
    public SkillCategory Category { get; set; }
}