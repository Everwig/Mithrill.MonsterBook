using System.Text.Json.Serialization;
using MediatR;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    public class GetGeneratedNpcQuery : IRequest<GeneratedNpc>
    {
        public bool IsUndead { get; set; }
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Difficulty? Difficulty { get; set; }
    }
}