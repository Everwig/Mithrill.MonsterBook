using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    internal class GetGeneratedNpcQueryHandler : IRequestHandler<GetGeneratedNpcQuery, GeneratedNpc>
    {
        private readonly NpcDesigner<IGeneratedCreature> _npcDesigner;
        private readonly IMapper _mapper;

        public GetGeneratedNpcQueryHandler(NpcDesigner<IGeneratedCreature> npcDesigner, IMapper mapper)
        {
            _npcDesigner = npcDesigner;
            _mapper = mapper;
        }

        public async Task<GeneratedNpc> Handle(GetGeneratedNpcQuery request, CancellationToken cancellationToken)
        {
            await _npcDesigner.DesignNpcAsync(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            var generatedMonster = _npcDesigner.GetNpc();

            return _mapper.Map<GeneratedNpc>(generatedMonster);
        }
    }
}