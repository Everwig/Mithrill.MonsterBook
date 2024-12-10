using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;
using Mithrill.MonsterBook.Domain.ValueObjects;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public sealed record Merit(int Id, bool IsOptional) : AggregateRoot<int>(Id), IMapTo<CharacterMerit>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Merit, CharacterMerit>()
            .ForMember(characterMerit => characterMerit.Merit, opt => opt.Ignore())
            .ForMember(characterMerit => characterMerit.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterMerit => characterMerit.MeritId, opt => opt.MapFrom(merit => merit.Id))
            .ForMember(characterMerit => characterMerit.NpcTemplateId, opt => opt.Ignore());
    }
}