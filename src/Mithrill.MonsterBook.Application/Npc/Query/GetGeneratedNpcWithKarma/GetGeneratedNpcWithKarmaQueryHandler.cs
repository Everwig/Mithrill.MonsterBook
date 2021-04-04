using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma
{
    internal class GetGeneratedNpcWithKarmaQueryHandler : IRequestHandler<GetGeneratedNpcWithKarmaQuery, GeneratedNpcWithKarma>
    {
        private readonly NpcDesigner<IGeneratedCreature> _npcDesigner;
        private readonly IMapper _mapper;

        public GetGeneratedNpcWithKarmaQueryHandler(NpcDesigner<IGeneratedCreature> npcDesigner, IMapper mapper)
        {
            _npcDesigner = npcDesigner;
            _mapper = mapper;
        }

        public async Task<GeneratedNpcWithKarma> Handle(GetGeneratedNpcWithKarmaQuery request, CancellationToken cancellationToken)
        {
            await _npcDesigner.DesignNpcWithKarma(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            var generatedMonster = _npcDesigner.GetNpc();

            return _mapper.Map<GeneratedNpcWithKarma>(generatedMonster);
        }
    }
}