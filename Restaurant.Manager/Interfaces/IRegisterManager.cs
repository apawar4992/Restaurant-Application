using Restaurant.Model;

namespace Restaurant.Manager.Interfaces
{
    public interface IRegisterManager
    {
        Task<bool> RegisterUser(User user);

        Task<User> GetUserProfile(string emailAddress);
    }
}
