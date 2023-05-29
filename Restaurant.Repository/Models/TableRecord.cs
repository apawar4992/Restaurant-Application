using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class TableRecord
{
    public string TableNumber { get; set; } = null!;

    public string? Details { get; set; }

    public virtual ICollection<BookingRecord> Bookings { get; set; } = new List<BookingRecord>();
}
