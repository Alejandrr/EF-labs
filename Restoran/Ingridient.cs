using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restoran;

public partial class Ingridient
{
    [Key]
    public short IId { get; set; }

    public string? IName { get; set; }

    public decimal? IWeight { get; set; }

    public bool? IAviable { get; set; }

    public decimal? IPriceFromZavod { get; set; }

    public virtual ICollection<Dish> Recepts { get; } = new List<Dish>();
}
