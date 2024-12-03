using System.Collections.Generic;

namespace Mithrill.MonsterBook.Application.Common;

public sealed record ArcanumRanks(
    Arcanum Primary,
    Arcanum Secondary,
    HashSet<Arcanum> Tertiaries,
    Arcanum? Quaternary,
    Arcanum? Quinary
);