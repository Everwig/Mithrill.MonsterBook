using MediatR;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster
{
    public class GetGeneratedMonsterQuery : IRequest<GeneratedMonster>
    {
        public bool IsUndead { get; set; }
        public int Id { get; set; }
        public Difficulty? Difficulty { get; set; }
    }
}