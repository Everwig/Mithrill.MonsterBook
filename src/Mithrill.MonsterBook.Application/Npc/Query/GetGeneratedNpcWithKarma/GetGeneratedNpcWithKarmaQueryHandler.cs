using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma
{
    internal class GetGeneratedNpcWithKarmaQueryHandler : IRequestHandler<GetGeneratedNpcWithKarmaQuery, GeneratedNpcWithKarma>
    {
        private readonly NpcDesigner<GeneratedNpcWithKarma> _npcDesigner;

        public GetGeneratedNpcWithKarmaQueryHandler(NpcDesigner<GeneratedNpcWithKarma> npcDesigner)
        {
            _npcDesigner = npcDesigner;
        }

        public async Task<GeneratedNpcWithKarma> Handle(GetGeneratedNpcWithKarmaQuery request, CancellationToken cancellationToken)
        {
            await _npcDesigner.DesignNpcWithKarma(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            var generatedMonster = _npcDesigner.GetNpc();

            return generatedMonster;
        }
    }
}