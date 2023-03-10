using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran;

[Table("Workers")]
public class Worker 
{
    [Key]
    public short WId { get; set; }

    public string WPib { get; set; } = null!;

    public string WDocument { get; set; } = null!;

    public string WIpn { get; set; } = null!;

    public decimal WSalary { get; set; }
    public virtual ICollection<Ordering> Orderings { get; } = new List<Ordering>();

}
