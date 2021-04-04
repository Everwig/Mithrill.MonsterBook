using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    internal class GetGeneratedProminentNpcQueryHandler : IRequestHandler<GetGeneratedProminentNpcQuery, GeneratedProminentNpc>
    {
        private readonly NpcDesigner<IGeneratedCreature> _npcDesigner;
        private readonly IMapper _mapper;

        public GetGeneratedProminentNpcQueryHandler(NpcDesigner<IGeneratedCreature> npcDesigner, IMapper mapper)
        {
            _npcDesigner = npcDesigner;
            _mapper = mapper;
        }

        public async Task<GeneratedProminentNpc> Handle(GetGeneratedProminentNpcQuery request, CancellationToken cancellationToken)
        {
            await _npcDesigner.DesignProminentNpcAsync(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            var generatedMonster = _npcDesigner.GetNpc();

            return _mapper.Map<GeneratedProminentNpc>(generatedMonster);
        }
    }
}