using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class SaleDetailRecord
{
    public DateTime Date { get; set; }

    public int Daily { get; set; }

    public int? Weekly { get; set; }

    public int? Monthly { get; set; }

    public string? Rname { get; set; }
}
