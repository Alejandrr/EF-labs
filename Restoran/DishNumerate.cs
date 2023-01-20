using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restoran;

public partial class DishNumerate
{
    [Key]
    public short DnId { get; set; }

    public decimal? DnPrice { get; set; }

    public DateTime? DnTimestamp { get; set; }

    public int DnDishes { get; set; }

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}
