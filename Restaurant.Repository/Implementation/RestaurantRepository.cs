using Restaurant.Repository.Models;
using Restaurant.Repository.Interfaces;
using Restaurant.Model;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Repository.Implementation
{
    public class RestaurantRepository : IRestaurantRepository
    {
        #region Public Methods

        public async Task<List<Model.Restaurant>> GetRestaurants(bool isOwnerRequired = false)
        {
            List<Model.Restaurant> RestaurantList = new List<Model.Restaurant>();
            List<RestaurantRecord> restaurantRecords;
            using (RestaurantContext context = new RestaurantContext())
            {
                restaurantRecords = await context.Restaurants.ToListAsync();
            }

            foreach (var restaurantRecord in restaurantRecords)
            {
                List<Owner> owners = new List<Owner>();
                if (isOwnerRequired)
                {
                    owners = await GetRestaurantOwners(restaurantRecord.Name);
                }

                RestaurantList.Add(new Model.Restaurant()
                {
                    Name = restaurantRecord.Name,
                    Owners = owners,
                    Contact = restaurantRecord.Contact,
                    Location = restaurantRecord.Location,
                    Details = restaurantRecord.Details,
                    OpeningClosingTime = restaurantRecord.OpeningClosingTime
                });
            }

            return RestaurantList;
        }

        public async Task<bool> AddRestaurant(Model.Restaurant restaurant)
        {
            RestaurantRecord record = new RestaurantRecord()
            {
                Name = restaurant.Name,
                Contact = restaurant.Contact,
                Location = restaurant.Location,
                Details = restaurant.Details,
                OpeningClosingTime = restaurant.OpeningClosingTime,
                Owners = (ICollection<OwnerRecord>)restaurant.Owners
            };
            using (RestaurantContext context = new RestaurantContext())
            {
                await context.Restaurants.AddAsync(record);
                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> UpdateRestaurant(string restaurantName, Model.Restaurant restaurant)
        {
            RestaurantRecord restaurantRecord;
            using (RestaurantContext context = new RestaurantContext())
            {
                restaurantRecord = await context.Restaurants
                                          .FindAsync(restaurantName);
                if (restaurantRecord == null)
                {
                    // Exception record not found.
                }

                restaurantRecord.Contact = restaurant.Contact;
                restaurantRecord.Location = restaurant.Location;
                restaurantRecord.Details = restaurant.Details;
                restaurantRecord.OpeningClosingTime = restaurant.OpeningClosingTime;
                restaurantRecord.Owners = (ICollection<OwnerRecord>)restaurant.Owners;

                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteRestaurant(Model.Restaurant restaurant)
        {
            RestaurantRecord restaurantRecord;
            using (RestaurantContext context = new RestaurantContext())
            {
                restaurantRecord = await context.Restaurants.FindAsync(restaurant.Name);
                if (restaurantRecord == null)
                {
                    // Exception Not found.
                }

                context.Restaurants.Remove(restaurantRecord);
                await context.SaveChangesAsync();
            }

            return true;
        }

        #endregion

        #region Private Members

        private async Task<List<Owner>> GetRestaurantOwners(string restaurantName)
        {
            List<Owner> restaurantOwners = new List<Owner>();
            try
            {
                using (RestaurantContext context = new RestaurantContext())
                {
                    List<OwnerRecord> ownerRecords = await context.Owners
                                                                  .Where(item => item.RestName.Equals(restaurantName)).ToListAsync();
                    if (ownerRecords?.Count > 0)
                    {
                        ownerRecords.ForEach(restaurantOwnerItem =>
                        {
                            restaurantOwners.Add(new Owner()
                            {
                                Contact = restaurantOwnerItem.Contact,
                                Fname = restaurantOwnerItem.Fname,
                                Lname = restaurantOwnerItem.Lname,
                                RestName = restaurantOwnerItem.RestName,
                            });
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return restaurantOwners;
        }

        #endregion
    }
}
