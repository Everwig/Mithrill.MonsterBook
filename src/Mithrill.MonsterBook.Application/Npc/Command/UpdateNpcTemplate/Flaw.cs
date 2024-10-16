using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public class Flaw : IMapTo<CharacterFlaw>
{
    public int Id { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Flaw, CharacterFlaw>()
            .ForMember(characterMerit => characterMerit.Flaw, opt => opt.Ignore())
            .ForMember(characterMerit => characterMerit.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterMerit => characterMerit.FlawId, opt => opt.MapFrom(merit => merit.Id))
            .ForMember(characterMerit => characterMerit.NpcTemplateId, opt => opt.Ignore());
    }
}