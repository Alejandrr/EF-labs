using System;
using System.Collections.Generic;

namespace Restoran3;

public partial class Dish
{
    public short DId { get; set; }

    public string DName { get; set; } = null!;

    public string? DType { get; set; }

    public bool? DAviable { get; set; }

    public int? DCalority { get; set; }

    public decimal? DPrice { get; set; }

    public virtual ICollection<Recept> Recepts { get; } = new List<Recept>();
}
