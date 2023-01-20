using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Position
{
    public short Pid { get; set; }

    public short Pchairs { get; set; }

    public string? Ptype { get; set; }

    public string? ProomType { get; set; }

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}
