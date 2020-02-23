using MediatR;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster
{
    public class GetGeneratedMonsterQuery : IRequest<GeneratedMonster>
    {
        public int Id { get; set; }
    }
}