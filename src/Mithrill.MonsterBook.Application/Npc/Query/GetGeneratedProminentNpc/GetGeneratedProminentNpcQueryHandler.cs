using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    internal class GetGeneratedProminentNpcQueryHandler : IRequestHandler<GetGeneratedProminentNpcQuery, GeneratedProminentNpc>
    {
        private readonly NpcDesigner<GeneratedProminentNpc> _npcDesigner;

        public GetGeneratedProminentNpcQueryHandler(NpcDesigner<GeneratedProminentNpc> npcDesigner)
        {
            _npcDesigner = npcDesigner;
        }

        public async Task<GeneratedProminentNpc> Handle(GetGeneratedProminentNpcQuery request, CancellationToken cancellationToken)
        {
            await _npcDesigner.DesignProminentNpcAsync(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            var generatedMonster = _npcDesigner.GetNpc();

            return generatedMonster;
        }
    }
}