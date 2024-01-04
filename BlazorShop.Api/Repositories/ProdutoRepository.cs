using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository( AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> getItem(int productId)
        {
            var product = await _context.tb_Product
                            .Include(c => c.Category)
                            .SingleOrDefaultAsync(c => c.productId == productId);

            return product;
        }

        public async Task<IEnumerable<Product>> getItems()
        {
            var product = await _context.tb_Product
                              .Include(c => c.Category)
                              .ToListAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> getItemsByCatgory(int id)
        {
            var product = await _context.tb_Product
                            .Include(c => c.Category)
                            .Where(c => c.CategoryId == id).ToListAsync();
            return product;
        }
        public async Task<IEnumerable<Category>> getCategories()
        {
            var categories = await _context.tb_Category.ToListAsync();
            return categories;
        }
    }
}
