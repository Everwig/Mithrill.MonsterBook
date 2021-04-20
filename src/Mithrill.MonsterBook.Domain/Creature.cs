using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHu { get; set; }
        public int StrengthMax { get; set; }
        public int StrengthMin { get; set; }
        public int VitalityMax { get; set; }
        public int VitalityMin { get; set; }
        public int BodyMax { get; set; }
        public int BodyMin { get; set; }
        public int AgilityMax { get; set; }
        public int AgilityMin { get; set; }
        public int DexterityMax { get; set; }
        public int DexterityMin { get; set; }
        public int IntelligenceMax { get; set; }
        public int IntelligenceMin { get; set; }
        public int WillpowerMax { get; set; }
        public int WillpowerMin { get; set; }
        public int EmotionMax { get; set; }
        public int EmotionMin { get; set; }
        public int DamageReductionMax { get; set; }
        public int DamageReductionMin { get; set; }
        public int KarmaMax { get; set; }
        public int KarmaMin { get; set; }
        public bool IsUndead { get; set; }
        public Difficulty Difficulty { get; set; }
        public CreatureSkillCategories CreatureSkillCategories { get; set; }
        public ICollection<CreatureMerit> CreatureMerits { get; set; }
        public ICollection<CreatureFlaw> CreatureFlaws { get; set; }
        public ICollection<CreatureWeapon> CreatureWeapons { get; set; }
        public ICollection<CreatureSkill> CreatureSkills { get; set; }
    }
}