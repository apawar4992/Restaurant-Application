using Restaurant.Model;

namespace Restaurant.Repository.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetMenus();

        Task<List<Menu>> GetMenusByCategory(string categoryType);

        Task<List<string>> GetMenuTypes();

        Task<bool> AddMenu(Menu Menu);

        Task<bool> UpdateMenu(string MenuName, Menu Menu);

        Task<bool> DeleteMenu(Menu Menu);
    }
}
