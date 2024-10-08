using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class Merit : IMapFrom<CharacterMerit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOptional { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CharacterMerit, Merit>()
                .ForMember(npc => npc.Id, opt => opt.MapFrom(creature => creature.MeritId))
                .ForMember(npc => npc.Name, opt => opt.MapFrom(creature => creature.Merit.Name))
                .ForMember(npc => npc.IsOptional, opt => opt.MapFrom(creature => creature.IsOptional));
        }
    }
}