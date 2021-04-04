using MediatR;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma
{
    public class GetGeneratedNpcWithKarmaQuery : IRequest<GeneratedNpcWithKarma>
    {
        public bool IsUndead { get; set; }
        public int Id { get; set; }
        public Difficulty? Difficulty { get; set; }
    }
}