using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record Merit (int Id, string Name) : IMapFrom<Domain.Merit>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Merit, Merit>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(merit => merit.Id))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(merit => merit.Name));
    }
}