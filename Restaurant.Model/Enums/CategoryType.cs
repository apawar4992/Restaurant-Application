using System.ComponentModel;

namespace Restaurant.Model.Enums
{
    public enum CategoryType
    {
        [Description("afters")]
        Afters,

        [Description("beverage")]
        Beverage,

        [Description("dessert")]
        Dessert,

        [Description("SeaFood")]
        SeaFood,

        [Description("Side Orders - Bread")]
        SideOrdersBread,

        [Description("Side Orders - Rice")]
        SideOrdersRice,

        [Description("Side Orders - Sundries")]
        SideOrdersSundries,

        [Description("Starters")]
        SideOrdersStarters,

        [Description("Tandoori Specials")]
        TandooriSpcials,

        [Description("Vegetable Dishes")]
        VegetableDishes
    }
}
