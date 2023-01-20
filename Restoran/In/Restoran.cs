using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Restoran
{
    public short Rid { get; set; }

    public string Rname { get; set; } = null!;

    public string Raddress { get; set; } = null!;

    public short Rtables { get; set; }

    public int Rworkers { get; set; }

    public int? Rclients { get; set; }
}
