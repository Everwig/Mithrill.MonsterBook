using MediatR;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreature
{
    public class GetCreatureQuery : IRequest<Creature>
    {
        public int Id { get; set; }
    }
}