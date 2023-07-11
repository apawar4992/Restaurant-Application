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
        #region Private Members
        
        private IMenuManager _menuManager;
        private ITokenManager _tokenManager;

        #endregion
        
        #region Constructor

        public MenuController(IMenuManager menuManager, ITokenManager tokenManager)
        {
            _menuManager = menuManager;
            _tokenManager = tokenManager;
        }

        #endregion
        
        #region Get Menu

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
                return await _menuManager.GetMenusByCategory(categoryType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetMenuByName")]
        public async Task<Restaurant.Model.Menu> GetMenuByName(string name)
        {
            try
            {
                return await _menuManager.GetMenusByName(name);
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
        //[Authorize]
        public IActionResult Add(Restaurant.Model.Menu menu)
        {
            try
            {
                var validation = _tokenManager.ValidateToken(GetTokenFromRequestHeader());
                if (validation != TokenValidationError.Ok)
                {
                    return Unauthorized(new { message = validation.ToString() });
                }

                Task<bool> isTrue = _menuManager.AddMenu(menu);
                return Ok(isTrue.Result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update

        [HttpPut("{menuName}")]
        //[Route("UpdateMenu")]
        //[Authorize]
        public IActionResult Update(string menuName, Restaurant.Model.Menu menu)
        {
            try
            {
                var validation = _tokenManager.ValidateToken(GetTokenFromRequestHeader());
                if (validation != TokenValidationError.Ok)
                {
                    return Unauthorized(new { message = validation.ToString() });
                }

                Task<bool> isTrue = _menuManager.UpdateMenu(menuName, menu);
                return Ok(isTrue.Result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        [HttpDelete("{menuName}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(string menuName)
        {
            try
            {
                var validation = _tokenManager.ValidateToken(GetTokenFromRequestHeader());
                if (validation != TokenValidationError.Ok)
                {
                    return Unauthorized(new { message = validation.ToString() });
                }

                Task<bool> isTrue = _menuManager.DeleteMenu(menuName);
                return Ok(isTrue.Result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private string GetTokenFromRequestHeader()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
        }

        #endregion
    }
}