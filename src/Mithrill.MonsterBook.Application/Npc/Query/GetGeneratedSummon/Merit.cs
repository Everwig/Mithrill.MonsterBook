using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

public sealed record Merit(int Id, string Name) : IMapTo<Domain.Merit>
{


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Merit, Merit>()
            .ForCtorParam(ctorParamName: nameof(Id), option => option.MapFrom(merit => merit.Id))
            .ForCtorParam(ctorParamName: nameof(Name), option => option.MapFrom(merit => merit.Name));
    }
}