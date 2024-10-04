using System.Text.Json.Serialization;

namespace Mithrill.MonsterBook.Application.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Difficulty
    {
        Newbie,
        Experienced,
        Expert,
        Veteran,
        Demigodly,
        Godly,
        Variable
    }
}