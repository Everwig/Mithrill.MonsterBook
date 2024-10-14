using System.Collections.Generic;

namespace Mithrill.MonsterBook.Application.Common;

public class ArcanumRanks
{
    public ArcanumRanks()
    {
        Tertiaries = new List<Arcanum>();
    }

    public Arcanum Primary { get; set; }
    public Arcanum Secondary { get; set; }
    public IEnumerable<Arcanum> Tertiaries { get; set; }
    public Arcanum? Quaternary { get; set; }
    public Arcanum? Quinary { get; set; }
}