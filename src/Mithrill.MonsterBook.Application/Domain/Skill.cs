using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Skill : ISkill
    {
        public int Name { get; set; }
        public int Level { get; set; }
    }
}