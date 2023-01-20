using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Worker
{
    public short Wid { get; set; }

    public string Wpib { get; set; } = null!;

    public string Wdocument { get; set; } = null!;

    public string Wipn { get; set; } = null!;

    public decimal Wsalary { get; set; }

    public short? WpostId { get; set; }

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();

    public virtual WorkRank? Wpost { get; set; }
}
