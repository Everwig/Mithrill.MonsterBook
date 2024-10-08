using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class NpcTemplate
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
        public Race Race { get; set; }
        public Difficulty Difficulty { get; set; }
        public CharacterSkillCategories CharacterSkillCategories { get; set; }
        public ICollection<CharacterMerit> CreatureMerits { get; set; }
        public ICollection<CharacterFlaw> CreatureFlaws { get; set; }
        public ICollection<CharacterWeapon> CreatureWeapons { get; set; }
        public ICollection<CharacterArmor> CreatureArmors { get; set; }
        public ICollection<CharacterSkill> CreatureSkills { get; set; }
    }
}