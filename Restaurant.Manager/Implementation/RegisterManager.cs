using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using Restaurant.Repository.Interfaces;

namespace Restaurant.Manager.Implementation
{
    public class RegisterManager : IRegisterManager
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterManager(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Task<bool> RegisterUser(User user)
        {
			try
			{
                return _registerRepository.RegisterUser(user);
			}
			catch (Exception)
			{
				throw;
			}
        }

        public async Task<User> GetUserProfile(string emailAddress)
        {
            try
            {
                return await _registerRepository.GetUserProfile(emailAddress);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
