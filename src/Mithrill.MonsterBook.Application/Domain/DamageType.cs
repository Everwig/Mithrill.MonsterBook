using System.Text.Json.Serialization;

namespace Mithrill.MonsterBook.Application.Domain;

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