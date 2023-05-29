using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class MenuRecord
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string? Type { get; set; }

    public string Category { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageLink { get; set; }
}
