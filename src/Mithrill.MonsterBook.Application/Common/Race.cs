using System.Text.Json.Serialization;

namespace Mithrill.MonsterBook.Application.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Race
    {
        Goblin,
        CivilizedHuman,
        Barbarian,
        AncientOrc,
        Orc,
        HalfOrc,
        Elf,
        DarkElf,
        HalfElf,
        HalfDarkElf,
        Dwarf,
        Animal,
        Bug,
        Dragon,
        Mythical,
        CreatureOfDarkness,
        CreatureOfLight
    }
}