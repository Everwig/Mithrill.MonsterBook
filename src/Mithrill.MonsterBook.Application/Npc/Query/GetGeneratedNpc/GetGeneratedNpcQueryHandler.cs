using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    internal class GetGeneratedNpcQueryHandler : IRequestHandler<GetGeneratedNpcQuery, GeneratedNpc>
    {
        private readonly NpcDesigner<GeneratedNpc> _npcDesigner;

        public GetGeneratedNpcQueryHandler(NpcDesigner<GeneratedNpc> npcDesigner)
        {
            _npcDesigner = npcDesigner;
        }

        public async Task<GeneratedNpc> Handle(GetGeneratedNpcQuery request, CancellationToken cancellationToken)
        {
            await _npcDesigner.DesignNpcAsync(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            var generatedMonster = _npcDesigner.GetNpc();

            return generatedMonster;
        }
    }
}