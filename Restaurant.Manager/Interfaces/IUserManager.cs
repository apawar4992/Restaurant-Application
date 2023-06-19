using Restaurant.Model;

namespace Restaurant.Manager.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetUser(UserCredentials userCredentials);
    }
}
