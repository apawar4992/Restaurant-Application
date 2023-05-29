using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class CustomerRecord
{
    public int CustomerId { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Contact { get; set; }

    public string? EmailId { get; set; }

    public virtual ICollection<BookingRecord> Bookings { get; set; } = new List<BookingRecord>();
}
