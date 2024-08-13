using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class Flaw : IMapFrom<MonsterBook.Domain.CreatureFlaw>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CreatureFlaw, Flaw>()
            .ForMember(flaw => flaw.Id, opt => opt.MapFrom(creatureFlaw => creatureFlaw.FlawId))
            .ForMember(flaw => flaw.Name, opt => opt.MapFrom(creatureFlaw => creatureFlaw.Flaw.Name));
    }
}