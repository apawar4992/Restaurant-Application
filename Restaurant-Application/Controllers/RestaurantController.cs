using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Manager.Interfaces;

namespace Restaurant_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class RestaurantController : ControllerBase
    {
        IRestaurantManager _restaurantManager;
        public RestaurantController(IRestaurantManager restaurantManager)
        {
            _restaurantManager = restaurantManager;
        }

        [HttpGet]
        public async Task<List<Restaurant.Model.Restaurant>> Get(bool isOwnerRequired = false)
        {
            try
            {
                return await _restaurantManager.GetRestaurants(isOwnerRequired);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public bool Add(Restaurant.Model.Restaurant restaurant)
        {
            try
            {
                _restaurantManager.AddRestaurant(restaurant);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        [HttpPut]
        public bool Update(string restaurantName, Restaurant.Model.Restaurant restaurant)
        {
            try
            {
                _restaurantManager.UpdateRestaurant(restaurantName, restaurant);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        [HttpDelete]
        public async Task<bool> Delete(Restaurant.Model.Restaurant restaurant)
        {
            try
            {
                return await _restaurantManager.DeleteRestaurant(restaurant);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
