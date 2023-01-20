using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Ingridient
{
    public short Iid { get; set; }

    public string? Iname { get; set; }

    public decimal? Iweight { get; set; }

    public bool? Iaviable { get; set; }

    public decimal? IpriceFromZavod { get; set; }

    public virtual ICollection<Recept> Recepts { get; } = new List<Recept>();
}
