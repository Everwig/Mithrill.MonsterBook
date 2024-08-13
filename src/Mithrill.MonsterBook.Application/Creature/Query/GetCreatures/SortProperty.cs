using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

[JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
public enum SortProperty
{
    [EnumMember(Value = "vitality")]
    Vitality,
    [EnumMember(Value = "body")]
    Body,
    [EnumMember(Value = "agility")]
    Agility,
    [EnumMember(Value = "dexterity")]
    Dexterity,
    [EnumMember(Value = "intelligence")]
    Intelligence,
    [EnumMember(Value = "willpower")]
    Willpower,
    [EnumMember(Value = "emotion")]
    Emotion,
    [EnumMember(Value = "karma")]
    Karma,
    [EnumMember(Value = "strength")]
    Strength,
    [EnumMember(Value = "race")]
    Race,
    [EnumMember(Value = "name")]
    Name,
    [EnumMember(Value = "id")]
    Id
}