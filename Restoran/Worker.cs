using System;
using System.Collections.Generic;

namespace Restoran;

public partial class Worker
{
    public short WId { get; set; }

    public string WPib { get; set; } = null!;

    public string WDocument { get; set; } = null!;

    public string WIpn { get; set; } = null!;

    public decimal WSalary { get; set; }

    public short? WPostId { get; set; }

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();

    public virtual WorkRank? WPost { get; set; }
}
