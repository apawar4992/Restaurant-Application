using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using Restaurant.Repository.Interfaces;

namespace Restaurant.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
		{
			_userRepository = userRepository;	
		}

        public Task<User> GetUser(UserCredentials userCredentials)
        {
			try
			{
               return _userRepository.GetUser(userCredentials);
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}
