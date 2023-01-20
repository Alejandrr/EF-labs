using System;
using System.Collections.Generic;

namespace Restoran3;

public partial class Ordering
{
    public short OId { get; set; }

    public short OCId { get; set; }

    public short OWId { get; set; }

    public short OPId { get; set; }

    public short ODnId { get; set; }

    public DateTime? OTimestamp { get; set; }

    public byte OPosition { get; set; }

    public virtual Customer OC { get; set; } = null!;

    public virtual DishNumerate ODn { get; set; } = null!;

    public virtual Position OP { get; set; } = null!;

    public virtual Worker OW { get; set; } = null!;
}
