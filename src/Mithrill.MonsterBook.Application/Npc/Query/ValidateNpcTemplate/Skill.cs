namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public record Skill(
    int Id,
    int MinLevel,
    int MaxLevel,
    int GuaranteedSuccesses,
    bool IsOptional);