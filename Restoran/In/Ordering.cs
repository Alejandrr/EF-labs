using System;
using System.Collections.Generic;

namespace Restoran.In;

public partial class Ordering
{
    public short Oid { get; set; }

    public short Ocid { get; set; }

    public short Owid { get; set; }

    public short Opid { get; set; }

    public short OdnId { get; set; }

    public DateTime? Otimestamp { get; set; }

    public byte Oposition { get; set; }

    public virtual Customer Oc { get; set; } = null!;

    public virtual DishNumerate Odn { get; set; } = null!;

    public virtual Position Op { get; set; } = null!;

    public virtual Worker Ow { get; set; } = null!;
}
