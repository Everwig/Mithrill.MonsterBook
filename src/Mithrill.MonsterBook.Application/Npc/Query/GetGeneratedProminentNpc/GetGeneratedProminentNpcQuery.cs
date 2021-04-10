using System.Text.Json.Serialization;
using MediatR;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    public class GetGeneratedProminentNpcQuery : IRequest<GeneratedProminentNpc>
    {
        public bool IsEvil { get; set; }
        public bool IsUndead { get; set; }
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Difficulty? Difficulty { get; set; }
    }
}