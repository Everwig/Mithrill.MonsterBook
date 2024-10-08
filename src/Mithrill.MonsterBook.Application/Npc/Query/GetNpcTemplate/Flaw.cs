using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class Flaw : IMapFrom<CreatureFlaw>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOptional { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatureFlaw, Flaw>()
                .ForMember(npc => npc.Id, opt => opt.MapFrom(creature => creature.FlawId))
                .ForMember(npc => npc.Name, opt => opt.MapFrom(creature => creature.Flaw.Name))
                .ForMember(npc => npc.IsOptional, opt => opt.MapFrom(creature => creature.IsOptional));
        }
    }
}