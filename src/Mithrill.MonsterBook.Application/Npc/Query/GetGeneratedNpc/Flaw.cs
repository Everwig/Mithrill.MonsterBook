using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record Flaw(int Id, string Name) : IMapFrom<Domain.Flaw>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Flaw, Flaw>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(flaw => flaw.Id))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(flaw => flaw.Name));
    }
}