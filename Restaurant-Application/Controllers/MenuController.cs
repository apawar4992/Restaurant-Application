using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Manager.Interfaces;

namespace Restaurant_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class MenuController : ControllerBase
    {
        private IMenuManager _menuManager;
        public MenuController(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        [HttpGet]
        public async Task<List<Restaurant.Model.Menu>> Get()
        {
            try
            {
                return await _menuManager.GetMenus();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetMenuByCategoryType")]
        public async Task<List<Restaurant.Model.Menu>> GetMenu(string categoryType)
        {
            try
            {
                return await _menuManager.GetMenus(categoryType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetMenuTypes")]
        public async Task<List<string>> GetMenuTypes()
        {
            try
            {
                return await _menuManager.GetMenuTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public bool Add(Restaurant.Model.Menu menu)
        {
            try
            {
                _menuManager.AddMenu(menu);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        [HttpPut]
        public bool Update(string menuName, Restaurant.Model.Menu menu)
        {
            try
            {
                _menuManager.UpdateMenu(menuName, menu);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        [HttpDelete]
        public async Task<bool> Delete(Restaurant.Model.Menu menu)
        {
            try
            {
                return await _menuManager.DeleteMenu(menu);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
