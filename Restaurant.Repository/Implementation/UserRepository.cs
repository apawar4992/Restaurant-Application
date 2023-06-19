using Microsoft.EntityFrameworkCore;
using Restaurant.Model;
using Restaurant.Repository.Interfaces;
using Restaurant.Repository.Models;

namespace Restaurant.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        public async Task<User> GetUser(UserCredentials userCredentials)
        {
            try
            {
                User user = new User();
                UserRecord userRecord;
                using (RestaurantContext context = new RestaurantContext())
                {
                    userRecord = await context.Users.FirstOrDefaultAsync(item => item.Password.Equals(userCredentials.password) && item.Email.Equals(userCredentials.username));
                }

                if (userRecord != null)
                {
                    user = new User()
                    {
                        Fname = userRecord.Fname,
                        Lname = userRecord.Lname,
                        Password = userRecord.Password,
                        Email = userRecord.Email,
                        Role = userRecord.Role
                    };
                }

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
