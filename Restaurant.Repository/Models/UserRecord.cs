using System;
using System.Collections.Generic;

namespace Restaurant.Repository.Models;

public partial class UserRecord
{
    public int UserId { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string Email { get; set; } = null !;
    public string Role { get; set; } = null !;
}
