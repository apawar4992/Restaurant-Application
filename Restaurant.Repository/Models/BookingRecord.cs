using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class BookingRecord
{
    public int BookingId { get; set; }

    public string TableNum { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public int CustId { get; set; }

    public virtual CustomerRecord Cust { get; set; } = null!;

    public virtual TableRecord TableNumNavigation { get; set; } = null!;
}
