using System.ComponentModel;

namespace Restaurant.Model.Enums
{
    public enum MenuType
    {
        [Description("Desserts")]
        Desserts,

        [Description("Drinks")]
        Drinks,

        [Description("Non-Veg")]
        NonVeg,

        [Description("Veg")]
        Veg
    }
}
