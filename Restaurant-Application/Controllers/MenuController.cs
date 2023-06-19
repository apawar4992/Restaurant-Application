using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Manager.Interfaces;
using Restaurant.Model.Enums;

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

        #region Get Menu

        [HttpGet]
        [Route("GetMenuByCategoryType")]
        public async Task<List<Restaurant.Model.Menu>> GetMenu(string categoryType)
        {
            try
            {
                return await _menuManager.GetMenusByCategory(categoryType);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Get Menu types API

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

        [HttpGet]
        [Route("GetMenus")]
        public async Task<List<object>> GetMenus()
        {
            List<object> list = new List<object>();
            try
            {
                List<string> menus = Enum.GetNames(typeof(MenuType)).ToList();
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

        #endregion

        #region Get Categories

        [HttpGet]
        [Route("GetCategories")]
        public async Task<List<object>> GetCategories()
        {
            List<object> list = new List<object>();
            try
            {
                List<string> categories = Enum.GetNames(typeof(CategoryType)).ToList();
                categories.ForEach(item =>
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

        #endregion

        #region Add Menu

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        #endregion

        #region Update

        [HttpPut]
        [Authorize(Roles = "Admin")]
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

        #endregion

        #region Delete

        [HttpDelete]
        [Authorize(Roles = "Admin")]
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

        #endregion
    }
}