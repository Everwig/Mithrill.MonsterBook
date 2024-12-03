using System.Text.Json.Serialization;

namespace Mithrill.MonsterBook.Application.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DamageType
{
    Slashing,
    Stabbing,
    Bludgeoning,
    Fire,
    Lightning,
    Ice,
    Light,
    Dark,
    Acid,
    Poison,
    None
}