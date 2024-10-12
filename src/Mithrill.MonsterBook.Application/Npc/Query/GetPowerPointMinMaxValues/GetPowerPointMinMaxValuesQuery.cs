using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetPowerPointMinMaxValues
{
    public class GetPowerPointMinMaxValuesQuery : IRequest<(int PowerPointMin, int PowerPointMax)>
    {
        public int KarmaMin { get; set; }
        public int KarmaMax { get; set; }
    }
}