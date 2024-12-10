using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

internal class GetGeneratedNpcQueryHandler : IRequestHandler<GetGeneratedNpcQuery, GeneratedNpc>
{
    private readonly NpcDesigner<GeneratedCreature> _npcDesigner;
    private readonly IMapper _mapper;

    public GetGeneratedNpcQueryHandler(NpcDesigner<GeneratedCreature> npcDesigner, IMapper mapper)
    {
        _npcDesigner = npcDesigner;
        _mapper = mapper;
    }

    public async Task<GeneratedNpc> Handle(GetGeneratedNpcQuery request, CancellationToken cancellationToken)
    {
        if (request.IsProminent)
        {
            await _npcDesigner.DesignProminentNpcAsync(request.Id, request.IsEvil, request.IsUndead, request.Difficulty, cancellationToken);
        }
        else if (request.HasKarma)
        {
            await _npcDesigner.DesignNpcWithKarmaAsync(request.Id, request.IsEvil, request.IsUndead, request.Difficulty, cancellationToken);
        }
        else
        {
            await _npcDesigner.DesignNpcAsync(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
        }

        var generatedNpc = _npcDesigner.GetNpc();

        return _mapper.Map<GeneratedNpc>(generatedNpc);
    }
}