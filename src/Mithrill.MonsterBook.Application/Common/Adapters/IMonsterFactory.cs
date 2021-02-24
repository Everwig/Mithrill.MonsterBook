using Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IMonsterFactory
    {
        GeneratedMonster CreateMonster(Domain.Creature creature);
    }
}