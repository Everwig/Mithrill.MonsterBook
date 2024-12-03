using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Merits.Query.GetAllForNpcTemplates;

public sealed record Merit(int Id, string Name) : IMapFrom<MonsterBook.Domain.Merit>;