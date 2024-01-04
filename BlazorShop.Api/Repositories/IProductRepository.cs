using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getItems();
        Task<IEnumerable<Product>> getItemsByCatgory(int id);
        Task<Product> getItem(int id);
        Task<IEnumerable<Category>> getCategories();

    }
}
