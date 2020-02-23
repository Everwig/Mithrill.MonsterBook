using MediatR;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetMonster
{
    public class GetMonsterQuery : IRequest<Monster>
    {
        public int Id { get; set; }
    }
}