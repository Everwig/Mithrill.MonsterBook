namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface ISkill
    {
        string Name { get; }
        string NameHu { get; }
        int Level { get; }
        public int GuaranteedSuccesses { get; set; }
        SkillCategory Category { get; }
    }
}