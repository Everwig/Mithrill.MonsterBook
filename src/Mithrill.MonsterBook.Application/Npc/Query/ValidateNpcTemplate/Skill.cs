namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public sealed record Skill(
    int Id,
    int MinLevel,
    int MaxLevel,
    int GuaranteedSuccesses,
    bool IsOptional);