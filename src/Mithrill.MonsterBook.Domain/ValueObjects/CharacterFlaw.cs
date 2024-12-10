using Mithrill.MonsterBook.Domain.Entities;

namespace Mithrill.MonsterBook.Domain.ValueObjects;

public class CharacterFlaw
{
    public int NpcTemplateId { get; set; }
    public NpcTemplate NpcTemplate { get; set; }
    public int FlawId { get; set; }
    public Flaw Flaw { get; set; }
    public bool IsOptional { get; set; }
}