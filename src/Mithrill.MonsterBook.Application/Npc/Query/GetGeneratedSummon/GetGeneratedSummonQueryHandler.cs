using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

internal sealed class GetGeneratedSummonQueryHandler : IRequestHandler<GetGeneratedSummonQuery, GeneratedSummon>
{
    private readonly IMapper _mapper;
    private readonly SummonDesigner<GeneratedCreature> _summonDesigner;

    public GetGeneratedSummonQueryHandler(IMapper mapper, SummonDesigner<GeneratedCreature> summonDesigner)
    {
        _mapper = mapper;
        _summonDesigner = summonDesigner;
    }

    public async Task<GeneratedSummon> Handle(GetGeneratedSummonQuery request, CancellationToken cancellationToken)
    {
        await _summonDesigner.DesignSummonAsync(request.Type, request.Level, cancellationToken);
        var summon = _summonDesigner.GetSummon();

        return _mapper.Map<GeneratedSummon>(summon);
    }
}