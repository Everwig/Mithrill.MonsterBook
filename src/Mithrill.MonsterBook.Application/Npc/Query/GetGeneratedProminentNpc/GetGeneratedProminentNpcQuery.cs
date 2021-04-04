using MediatR;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    public class GetGeneratedProminentNpcQuery : IRequest<GeneratedProminentNpc>
    {
        public bool IsUndead { get; set; }
        public int Id { get; set; }
        public Difficulty? Difficulty { get; set; }
    }
}