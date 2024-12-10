using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Skills.Query.GetAllForNpcTemplates;

public sealed record Skill (
    int Id,
    string Name,
    Attribute Attribute1,
    Attribute Attribute2,
    SkillCategory Category
) : IMapFrom<MonsterBook.Domain.Entities.Skill>;