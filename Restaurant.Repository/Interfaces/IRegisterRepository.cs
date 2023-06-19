using Restaurant.Model;

namespace Restaurant.Repository.Interfaces
{
    public interface IRegisterRepository
    {
        Task<bool> RegisterUser(User user);
        Task<User> GetUserProfile(string emailAddress);
    }
}
