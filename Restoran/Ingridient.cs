using System;
using System.Collections.Generic;

namespace Restoran;

public partial class Ingridient
{
    public short IId { get; set; }

    public string? IName { get; set; }

    public decimal? IWeight { get; set; }

    public bool? IAviable { get; set; }

    public decimal? IPriceFromZavod { get; set; }

    public virtual ICollection<Recept> Recepts { get; } = new List<Recept>();
}
