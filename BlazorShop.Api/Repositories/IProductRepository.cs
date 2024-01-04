using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getItems();
        Task<IEnumerable<Product>> getItemsByCatgory(int CategoryId);
        Task<Product> getItem(int productId);
        Task<IEnumerable<Category>> getCategories();

    }
}
