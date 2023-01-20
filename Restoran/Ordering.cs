using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restoran;

public partial class Ordering
{
    [Key]
    public short OId { get; set; }

    public short OCId { get; set; }

    public short OWId { get; set; }

    public short OPId { get; set; }

    public short ODnId { get; set; }

    public DateTime? OTimestamp { get; set; }

    public byte OPosition { get; set; }
    public  Customer? OC { get; set; } = null!;
    public  Position? OP { get; set; } = null!;
    
    
    public  Worker? OW { get; set; } = null!;
}
