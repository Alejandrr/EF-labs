using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran;

[Table("Workers")]
public partial class Worker :People
{
  
    public string WDocument { get; set; } = null!;

    public string WIpn { get; set; } = null!;

    public decimal WSalary { get; set; }
    public string? WRank { get; set; }
    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();

}
