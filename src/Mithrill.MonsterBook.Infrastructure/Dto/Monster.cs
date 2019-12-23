using System.Collections.Generic;

namespace Mithrill.MonsterBook.Infrastructure.Dto
{
    public class Monster
    {
        public int Id { get; set; }
        public int StrengthMax { get; set; }
        public int StrengthMin { get; set; }
        public int VitalityMax { get; set; }
        public int VitalityMin { get; set; }
        public int BodyMax { get; set; }
        public int BodyMin { get; set; }
        public int SpeedMax { get; set; }
        public int SpeedMin { get; set; }
        public int AgilityMax { get; set; }
        public int AgilityMin { get; set; }
        public int IntelligenceMax { get; set; }
        public int IntelligenceMin { get; set; }
        public int WillpowerMax { get; set; }
        public int WillpowerMin { get; set; }
        public int SensationMax { get; set; }
        public int SensationMin { get; set; }
        public int DamageReductionMax { get; set; }
        public int DamageReductionMin { get; set; }
        public ICollection<Merit> Merits { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}