using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class MenuBillRecord
{
    public int OrderId { get; set; }

    public string Name { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public double Price { get; set; }

    public virtual BillRecord Order { get; set; } = null!;
}
