using Restaurant.Manager.Interfaces;
using Restaurant.Repository.Interfaces;

namespace Restaurant.Manager.Implementation
{
    public class RestaurantManager : IRestaurantManager
    {
        IRestaurantRepository _restaurantRepository;

        public RestaurantManager(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<Model.Restaurant>> GetRestaurants(bool isOwnerRequired = false)
        {
            List<Model.Restaurant> restaurants = null;
            try
            {
                restaurants = await _restaurantRepository.GetRestaurants(isOwnerRequired);

            }
            catch (Exception)
            {
                throw;
            }

            return restaurants;
        }

        public async Task<bool> AddRestaurant(Model.Restaurant restaurant)
        {
            try
            {
                return await _restaurantRepository.AddRestaurant(restaurant);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRestaurant(string restaurantName, Model.Restaurant restaurant)
        {
            try
            {
                return await _restaurantRepository.UpdateRestaurant(restaurantName, restaurant);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRestaurant(Model.Restaurant restaurant)
        {
            try
            {
                return await _restaurantRepository.DeleteRestaurant(restaurant);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
