using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class AttackType : IMapFrom<MonsterBook.Domain.AttackType>
{
    public int Id { get; set; }
    public DamageType DamageType { get; set; }
    public int NumberOfDices { get; set; }
    public int GuaranteedDamage { get; set; }
    public bool IsBaseAttackType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.AttackType, AttackType>()
            .ForMember(attackType => attackType.IsBaseAttackType, opt => opt.Ignore());
    }
}