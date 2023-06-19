using System.ComponentModel;

namespace Restaurant.Model.Enums
{
    public enum RoleType
    {
        [Description("Admin")]
        Admin,

        [Description("User")]
        User,
    }
}
