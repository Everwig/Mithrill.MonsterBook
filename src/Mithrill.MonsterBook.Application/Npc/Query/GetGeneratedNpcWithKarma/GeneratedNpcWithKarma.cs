using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma
{
    public class GeneratedNpcWithKarma : IMapFrom<IGeneratedCreature>
    {
        public GeneratedNpcWithKarma()
        {
            Weapons = new List<Weapon>();
            Skills = new List<Skill>();
        }

        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Body { get; set; }
        public int Agility { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Willpower { get; set; }
        public int Emotion { get; set; }
        public int DamageReduction { get; set; }
        public int Karma { get; set; }
        public Difficulty Difficulty { get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public int PowerPoint { get; set; }
        public int ManaPoint { get; set; }
        public int HitPoint { get; set; }
    }
}