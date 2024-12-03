using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc;

public interface IRanks
{
    ArcanumRanks? ArcanumRanks { get; }
    SkillCategories? SkillCategories { get; }
}