using MediatR;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    public class GetGeneratedNpcQuery : IRequest<GeneratedNpc>
    {
        public bool IsUndead { get; set; }
        public int Id { get; set; }
        public Difficulty? Difficulty { get; set; }
    }
}