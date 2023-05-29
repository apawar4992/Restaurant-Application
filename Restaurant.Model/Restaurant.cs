
namespace Restaurant.Model
{
    public class Restaurant
    {
        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public string OpeningClosingTime { get; set; } = string.Empty;

        public string? Details { get; set; }

        public List<Owner> Owners { get; set; } = new List<Owner>();
    }
}
