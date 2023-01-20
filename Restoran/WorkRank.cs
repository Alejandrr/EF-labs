using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class WorkRank
{
    public short WrId { get; set; }

    public string? WrFullName { get; set; }

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
