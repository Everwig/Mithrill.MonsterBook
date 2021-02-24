using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Factories;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster
{
    internal class GetGeneratedMonsterQueryHandler : IRequestHandler<GetGeneratedMonsterQuery, GeneratedMonster>
    {
        private readonly IMonsterBookDbContext _monsterBookDbContext;
        private readonly IMonsterFactory _monsterFactory;
        private readonly NpcDesigner<GeneratedMonster> _npcDesigner;

        public GetGeneratedMonsterQueryHandler(IMonsterBookDbContext monsterBookDbContext, IMonsterFactory monsterFactory, NpcDesigner<GeneratedMonster> npcDesigner)
        {
            _monsterBookDbContext = monsterBookDbContext;
            _monsterFactory = monsterFactory;
            _npcDesigner = npcDesigner;
        }

        public async Task<GeneratedMonster> Handle(GetGeneratedMonsterQuery request, CancellationToken cancellationToken)
        {
            //With Factory
            var monster = await _monsterBookDbContext.Monsters
                .Where(m => m.Id == request.Id)
                .SingleAsync(cancellationToken);
            
            var generatedMonster = _monsterFactory.CreateMonster(monster);

            //With Builder Pattern
            await _npcDesigner.DesignSkeletonNpcAsync(request.Id, request.IsUndead, request.Difficulty, cancellationToken);
            generatedMonster = _npcDesigner.GetNpc();

            return generatedMonster;
        }
    }
}