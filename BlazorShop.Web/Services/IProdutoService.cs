using BlazorShop.Model.DTO_s;

namespace BlazorShop.Web.Services;

public interface IProdutoService
{
    Task<IEnumerable<Product_DTO>> GetItens();
    Task<Product_DTO> GetItem(int id);

    Task<IEnumerable<Category_DTO>> GetCategorias();
    Task<IEnumerable<Product_DTO>> GetItensPorCategoria(int categoriaId);
}
