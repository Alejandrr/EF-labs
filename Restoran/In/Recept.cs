using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Recept
{
    public short Rid { get; set; }

    public TimeSpan? RcookTime { get; set; }

    public short? Rdid { get; set; }

    public short? Riid { get; set; }

    public virtual Dish? Rd { get; set; }

    public virtual Ingridient? Ri { get; set; }
}
