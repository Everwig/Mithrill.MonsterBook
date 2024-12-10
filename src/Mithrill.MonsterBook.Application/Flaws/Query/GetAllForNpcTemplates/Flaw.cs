using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Flaws.Query.GetAllForNpcTemplates;

public sealed record Flaw (int Id, string Name) : IMapFrom<MonsterBook.Domain.Entities.Flaw>;