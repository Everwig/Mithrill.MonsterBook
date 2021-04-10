using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface ISkill
    {
        string Name { get; }
        string NameHu { get; }
        int Level { get; }
        SkillCategories Category { get; }
    }
}