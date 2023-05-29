using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class OwnerRecord
{
    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string RestName { get; set; } = null!;

    public virtual RestaurantRecord RestNameNavigation { get; set; } = null!;
}
