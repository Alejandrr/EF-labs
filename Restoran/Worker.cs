using Restoran.In;
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
    public int? WPostId { get; set; } = null;

    public decimal WSalary { get; set; }
    public  List<Ordering> Orderings { get; } = new List<Ordering>();
    public virtual WorkRank? WPost { get; set; }


}
