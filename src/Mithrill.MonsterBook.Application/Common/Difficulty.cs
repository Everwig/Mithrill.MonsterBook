using System.Text.Json.Serialization;

namespace Mithrill.MonsterBook.Application.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Difficulty
    {
        Newbie,
        Novice,
        Rookie,
        Beginner,
        Talented,
        Skilled,
        Intermediate,
        Skillful,
        Seasoned,
        Proficient,
        Experienced,
        Advanced,
        Senior,
        Expert
    }
}