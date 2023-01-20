using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Dish
{
    public short Did { get; set; }

    public string Dname { get; set; } = null!;

    public string? Dtype { get; set; }

    public bool? Daviable { get; set; }

    public int? Dcalority { get; set; }

    public decimal? Dprice { get; set; }

    public virtual ICollection<Recept> Recepts { get; } = new List<Recept>();
}
