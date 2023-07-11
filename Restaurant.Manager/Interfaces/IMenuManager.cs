using Restaurant.Model;

namespace Restaurant.Manager.Interfaces
{
    public interface IMenuManager
    {
        Task<List<Menu>> GetMenus();
        Task<List<Menu>> GetMenusByCategory(string categoryType);
        Task<Menu> GetMenusByName(string name);
        Task<List<string>> GetMenuTypes();
        Task<bool> AddMenu(Menu menu);
        Task<bool> UpdateMenu(string menuName, Menu menu);
        Task<bool> DeleteMenu(string menuName);
    }
}
