using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran;

public class Customer
{
    [Key]
    public short CId { get; set; }

    public string CPib { get; set; } = null!;
}

[Table("GoodCustomers")]
public partial class GoodCustomer:Customer
{
    public int AverageOrderPrice { get; set; }
}
[Table("BadCustomers")]
public partial class BadCustomer:Customer
{
    public string ReasonForDeleting { get; set; }
}
