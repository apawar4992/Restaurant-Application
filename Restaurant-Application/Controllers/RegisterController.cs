using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using Restaurant.Model.Enums;

namespace Restaurant_Application.Controllers
{
    [Route("api/[controller]")]
    [EnableCors()]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterManager _registerManager;
        public RegisterController(IRegisterManager registerManager)
        {
            _registerManager = registerManager;
        }

        [HttpPost]
        public async Task<bool> RegisterUser([FromBody] User user)
        {
            try
            {
               return await _registerManager.RegisterUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<User> GetUserProfile(string emailAddress)
        {
            try
            {
                return await _registerManager.GetUserProfile(emailAddress);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<List<object>> GetRoleTypes()
        {
            List<object> list = new List<object>();
            try
            {
                List<string> menus = Enum.GetNames(typeof(RoleType)).ToList();
                menus.ForEach(item =>
                {
                    list.Add(new
                    {
                        label = item,
                        value = item
                    });
                });
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }
    }
}
