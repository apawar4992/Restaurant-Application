namespace Restaurant.Model
{
    public class Menu
    {
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; } = 0.0D;

        public string? Type { get; set; }

        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageLink { get; set; }
    }
}
