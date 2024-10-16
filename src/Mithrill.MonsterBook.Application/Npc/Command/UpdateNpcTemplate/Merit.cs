using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public class Merit : IMapTo<CharacterMerit>
{
    public int Id { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Merit, CharacterMerit>()
            .ForMember(characterMerit => characterMerit.Merit, opt => opt.Ignore())
            .ForMember(characterMerit => characterMerit.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterMerit => characterMerit.MeritId, opt => opt.MapFrom(merit => merit.Id))
            .ForMember(characterMerit => characterMerit.NpcTemplateId, opt => opt.Ignore());
    }
}