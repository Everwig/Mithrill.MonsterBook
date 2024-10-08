namespace Mithrill.MonsterBook.Domain
{
    public class CharacterSkill
    {
        public int SkillLevelMin { get; set; }
        public int SkillLevelMax { get; set; }
        public int GuaranteedSuccesses { get; set; }
        public bool IsOptional { get; set; }

        public int NpcTemplateId { get; set; }
        public NpcTemplate NpcTemplate { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}