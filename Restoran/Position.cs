using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restoran;

public partial class Position
{
    [Key]
    public short PId { get; set; }

    public short PChairs { get; set; }

    public string? PType { get; set; }

    public string? PRoomType { get; set; }

    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}
