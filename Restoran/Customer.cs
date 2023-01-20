using System;
using System.Collections.Generic;

namespace Restoran3;

public partial class Customer
{
    public short CId { get; set; }

    public string CPib { get; set; } = null!;

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}
