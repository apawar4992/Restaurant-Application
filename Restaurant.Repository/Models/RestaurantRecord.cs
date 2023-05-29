using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class RestaurantRecord
{
    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string OpeningClosingTime { get; set; } = null!;

    public string? Details { get; set; }

    public virtual ICollection<OwnerRecord> Owners { get; set; } = new List<OwnerRecord>();
}
