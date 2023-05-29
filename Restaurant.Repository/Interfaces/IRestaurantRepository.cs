namespace Restaurant.Repository.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Model.Restaurant>> GetRestaurants(bool isOwnerRequired);

        Task<bool> AddRestaurant(Model.Restaurant restaurant);

        Task<bool> UpdateRestaurant(string restaurantName, Model.Restaurant restaurant);

        Task<bool> DeleteRestaurant(Model.Restaurant restaurant);
    }
}
