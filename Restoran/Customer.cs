using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Restoran;

public class Customer
{
    [Key]
    public short CId { get; set; }

    public string CPib { get; set; } = null!;
    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();
}

public partial class GoodCustomer:Customer
{
    public int AverageOrderPrice { get; set; }
}
public partial class BadCustomer:Customer
{
    public string ReasonForDeleting { get; set; } = null;
}
