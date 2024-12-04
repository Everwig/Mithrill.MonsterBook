using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain;

internal class Weapon : IMapFrom<MonsterBook.Domain.Weapon>
{
    public string Name { get; set; }
    public AttackType AttackType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.Weapon, Weapon>()
            .ForMember(dest => dest.AttackType, opt => opt.Ignore());
    }
}