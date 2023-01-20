using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Restoran;
public class People
{
    [Key]
    public short CId { get; set; }

    public string CPib { get; set; } = null!;
}
public partial class Customer:People
{
    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}
