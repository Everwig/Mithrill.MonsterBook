using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public class Weapon : IMapFrom<Domain.Weapon>
{
    public string Name { get; set; }
    public AttackType AttackType { get; set; }
}