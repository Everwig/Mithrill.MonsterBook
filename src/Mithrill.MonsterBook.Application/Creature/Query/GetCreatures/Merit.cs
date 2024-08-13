using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class Merit : IMapFrom<MonsterBook.Domain.CreatureMerit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CreatureMerit, Merit>()
            .ForMember(merit => merit.Id, opt => opt.MapFrom(creatureMerit => creatureMerit.MeritId))
            .ForMember(merit => merit.Name, opt => opt.MapFrom(creatureMerit => creatureMerit.Merit.Name));
    }
}