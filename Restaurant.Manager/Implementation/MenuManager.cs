﻿using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using Restaurant.Repository.Interfaces;

namespace Restaurant.Manager.Implementation
{
    public class MenuManager : IMenuManager
    {
        IMenuRepository _menuRepository;

        public MenuManager(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        #region Public Methods

        public async Task<List<Menu>> GetMenus()
        {
            _ = new List<Menu>();
            List<Menu> menus;
            try
            {
                menus = await _menuRepository.GetMenus();
            }
            catch (Exception)
            {
                throw;
            }

            return menus;
        }

        public async Task<List<Menu>> GetMenusByCategory(string categoryType)
        {
            _ = new List<Menu>();
            List<Menu> menus;
            try
            {
                menus = await _menuRepository.GetMenusByCategory(categoryType);
            }
            catch (Exception)
            {
                throw;
            }

            return menus;
        }

        public async Task<Menu> GetMenusByName(string name)
        {
            try
            {
                return await _menuRepository.GetMenusByName(name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> GetMenuTypes()
        {
            try
            {
                return await _menuRepository.GetMenuTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddMenu(Menu menu)
        {
            try
            {
                return await _menuRepository.AddMenu(menu);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateMenu(string menuName, Menu menu)
        {
            try
            {
                return await _menuRepository.UpdateMenu(menuName, menu);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteMenu(string menuName)
        {
            try
            {
                return await _menuRepository.DeleteMenu(menuName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
