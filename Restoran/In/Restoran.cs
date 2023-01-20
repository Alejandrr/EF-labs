using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Restoran
{
    public short RId { get; set; }

    public string RName { get; set; } = null!;

    public string RAddress { get; set; } = null!;

    public short RTables { get; set; }

    public int RWorkers { get; set; }

    public int? RClients { get; set; }
}
