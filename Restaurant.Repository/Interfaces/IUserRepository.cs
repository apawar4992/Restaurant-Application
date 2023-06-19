using Restaurant.Model;

namespace Restaurant.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(UserCredentials userCredentials);
    }
}
