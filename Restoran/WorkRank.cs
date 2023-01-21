using System;
using System.Collections.Generic;

namespace Restoran3;

public partial class WorkRank
{
    public short WrId { get; set; }

    public string? WrFullName { get; set; }

    public virtual List<Worker> Workers { get; } = new List<Worker>();
}
