using Microsoft.EntityFrameworkCore;
using Restaurant.Model;
using Restaurant.Model.Enums;
using Restaurant.Repository.Interfaces;
using Restaurant.Repository.Models;

namespace Restaurant.Repository.Implementation
{
    public class RegisterRepository : IRegisterRepository
    {
        public async Task<bool> RegisterUser(User user)
        {
            try
            {
                UserRecord userRecord = new UserRecord()
                {
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Email = user.Email,
                    Role = user.Role,
                    Password = user.Password,
                };
                using (RestaurantContext context = new RestaurantContext())
                {
                    await context.Users.AddAsync(userRecord);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public async Task<User> GetUserProfile(string emailAddress)
        {
            User user = null;
            try
            {
                UserRecord userRecord;
                using (RestaurantContext context = new RestaurantContext())
                {
                    userRecord = await context.Users.Where(item => item.Email.Equals(emailAddress)).FirstOrDefaultAsync();
                }

                if (userRecord != null)
                {
                    user = new User()
                    {
                        Fname = userRecord.Fname,
                        Lname = userRecord.Lname,
                        Email = userRecord.Email,
                        Role = userRecord.Role,
                        Password = userRecord.Password
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }
    }
}
