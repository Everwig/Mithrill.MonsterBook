using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetManaPointMinMaxValues
{
    public class GetManaPointMinMaxValuesQuery : IRequest<(int ManaPointMin, int ManaPointMax)>
    {
        public int IntelligenceMin { get; set; }
        public int IntelligenceMax { get; set; }
        public int WillpowerMin { get; set; }
        public int WillpowerMax { get; set; }
        public int EmotionMin { get; set; }
        public int EmotionMax { get; set; }
        public IEnumerable<int> MeritIds { get; set; }
    }
}