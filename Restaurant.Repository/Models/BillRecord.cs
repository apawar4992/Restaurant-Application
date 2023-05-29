using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class BillRecord
{
    public int OrderId { get; set; }

    public string CustomerFname { get; set; } = null!;

    public string CustomerLname { get; set; } = null!;

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }
}
