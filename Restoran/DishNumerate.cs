using System;
using System.Collections.Generic;

namespace Restoran3;

public partial class DishNumerate
{
    public short DnId { get; set; }

    public decimal? DnPrice { get; set; }

    public DateTime? DnTimestamp { get; set; }

    public int DnDishes { get; set; }

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}
