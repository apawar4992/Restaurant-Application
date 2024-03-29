﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Model;
using Restaurant.Repository.Models;
using Restaurant.Repository.Interfaces;

namespace Restaurant.Repository.Implementation
{
    public class MenuRepository : IMenuRepository
    {
        public async Task<List<Menu>> GetMenus()
        {
            List<Menu> menuList = new List<Menu>();
            List<MenuRecord> menuRecords;
            using (RestaurantContext context = new RestaurantContext())
            {
                menuRecords = await context.Menus.ToListAsync();
            }

            if (menuRecords != null)
            {
                menuRecords.ForEach(item =>
                {
                    menuList.Add(new Menu()
                    {
                        Name = item.Name,
                        Category = item.Category,
                        Price = item.Price,
                        Type = item.Type,
                        Description = item.Description,
                        ImageLink = item.ImageLink,
                    });
                });
            }

            return menuList;
        }

        public async Task<List<Menu>> GetMenusByCategory(string categoryType)
        {
            List<Menu> menuList = new List<Menu>();
            List<MenuRecord> menuRecords;
            using (RestaurantContext context = new RestaurantContext())
            {
                menuRecords = await context.Menus.Where(item => item.Type == categoryType).ToListAsync();
            }

            if (menuRecords != null)
            {
                menuRecords.ForEach(item =>
                {
                    menuList.Add(new Menu()
                    {
                        Name = item.Name,
                        Category = item.Category,
                        Price = item.Price,
                        Type = item.Type,
                        Description = item.Description,
                        ImageLink = item.ImageLink
                    });
                });
            }

            return menuList;
        }

        public async Task<Menu> GetMenusByName(string name)
        {
            Menu menu = new Menu();
            MenuRecord menuRecord;
            using (RestaurantContext context = new RestaurantContext())
            {
                menuRecord = await context.Menus.Where(item => item.Name.Equals(name)).FirstOrDefaultAsync();
            }

            if (menuRecord != null)
            {
                    menu = new Menu()
                    {
                        Name = menuRecord.Name,
                        Category = menuRecord.Category,
                        Price = menuRecord.Price,
                        Type = menuRecord.Type,
                        Description = menuRecord.Description,
                        ImageLink = menuRecord.ImageLink
                    };
            }

            return menu;
        }

        public async Task<List<string>> GetMenuTypes()
        {
            List<string> menuTypes = new List<string>();
            try
            {
                using (RestaurantContext context = new RestaurantContext())
                {
                    var types = await context.Menus.GroupBy(item => item.Type)
                                                   .Select(i => i.Key).ToListAsync();

                    menuTypes = types.OfType<string>().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return menuTypes;
        }

        public async Task<bool> AddMenu(Menu Menu)
        {
            try
            {
                MenuRecord record = new MenuRecord()
                {
                    Name = Menu.Name,
                    Price = Menu.Price,
                    Type = Menu.Type,
                    Category = Menu.Category,
                    Description = Menu.Description,
                    ImageLink = Menu.ImageLink
                };
                using (RestaurantContext context = new RestaurantContext())
                {
                    await context.Menus.AddAsync(record);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> UpdateMenu(string MenuName, Menu menu)
        {
            MenuRecord menuRecord;
            using (RestaurantContext context = new RestaurantContext())
            {
                menuRecord = await context.Menus.FirstOrDefaultAsync(item => item.Name.Equals(MenuName));
                if (menuRecord == null)
                {
                    // Exception record not found.
                    return false;
                }

                menuRecord.Price = menu.Price;
                menuRecord.Category = menu.Category;
                //menuRecord.Name = menu.Name;
                menuRecord.Type = menu.Type;
                menuRecord.Description = menu.Description;
                menuRecord.ImageLink = menu.ImageLink;

                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteMenu(string menuName)
        {
            MenuRecord menuRecord;
            using (RestaurantContext context = new RestaurantContext())
            {
                menuRecord = await context.Menus.Where(item => item.Name.Equals(menuName)).FirstOrDefaultAsync();
                if (menuRecord == null)
                {
                    // Exception Not found.
                    return false;
                }

                context.Menus.Remove(menuRecord);
                await context.SaveChangesAsync();
            }

            return true;
        }
    }
}
