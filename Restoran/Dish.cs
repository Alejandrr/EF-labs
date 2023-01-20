using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restoran;

public partial class Dish
{
    [Key]
    public short DId { get; set; }

    public string DName { get; set; } = null!;

    public string? DType { get; set; }

    public bool? DAviable { get; set; }

    public int? DCalority { get; set; }

    public decimal? DPrice { get; set; }

    public  List<DishNumerate> Orderings { get; } = new List<DishNumerate>();

}
