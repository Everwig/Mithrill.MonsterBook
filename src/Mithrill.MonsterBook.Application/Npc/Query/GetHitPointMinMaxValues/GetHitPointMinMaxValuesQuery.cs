using MediatR;
using System.Collections.Generic;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetHitPointMinMaxValues
{
    public class GetHitPointMinMaxValuesQuery : IRequest<(int HitPointMin, int HitPointMax)>
    {
        public int StrengthMin { get; set; }
        public int StrengthMax { get; set; }
        public int BodyMin { get; set; }
        public int BodyMax { get; set; }
        public bool IsUndead { get; set; }
        public IEnumerable<int> MeritIds { get; set; }
    }
}