using BlazorShop.Model.DTO_s;

namespace BlazorShop.Web.Services;

public interface ICarrinhoCompraService
{
    Task<List<ShopItems_DTO>> GetItens(string usuarioId);
    Task<ShopItems_DTO> AdicionaItem(ShopCarItemsAdd_DTO carrinhoItemAdicionaDto);
    Task<ShopItems_DTO> DeleteItem(int id);
    Task<ShopItems_DTO> AtualizaQuantidade(ShopItemsUpdate_DTO carrinhoItemAtualizaQuantidadeDto);

    event Action<int> OnCarrinhoCompraChanged;
    void RaiseEventOnCarrinhoCompraChanged(int totalAmount);

}
