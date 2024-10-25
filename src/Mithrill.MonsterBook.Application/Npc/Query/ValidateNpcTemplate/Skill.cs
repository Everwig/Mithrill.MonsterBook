namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public class Skill
{
    public int Id { get; set; }
    public int MinLevel { get; set; }
    public int MaxLevel { get; set; }
    public int GuaranteedSuccesses { get; set; }
    public bool IsOptional { get; set; }
}