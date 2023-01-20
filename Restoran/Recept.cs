using System;
using System.Collections.Generic;

namespace Restoran3;

public partial class Recept
{
    public short RId { get; set; }

    public TimeSpan? RCookTime { get; set; }

    public short? RDId { get; set; }

    public short? RIId { get; set; }

    public virtual Dish? RD { get; set; }

    public virtual Ingridient? RI { get; set; }
}
