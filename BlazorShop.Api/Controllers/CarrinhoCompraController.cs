using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Model.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrinhoCompraController : ControllerBase
{
    private readonly IShopCarRepository carShopRepo;
    private readonly IProductRepository produtoRepo;

    private ILogger<CarrinhoCompraController> logger;

    public CarrinhoCompraController(IShopCarRepository
        carrinhoCompraRepository,
        IProductRepository produtoRepository,
        ILogger<CarrinhoCompraController> logger)
    {
        carShopRepo = carrinhoCompraRepository;
        produtoRepo = produtoRepository;
        this.logger = logger;
    }

    [HttpGet]
    [Route("{usuarioId}/GetItens")]
    public async Task<ActionResult<IEnumerable<ShopItems_DTO>>> GetItens(int usuarioId)
    {
        try
        {
            var carrinhoItens = await carShopRepo.GetItems(usuarioId);
            if (carrinhoItens == null)
            {
                return NoContent(); // 204 Status Code
            }

            var produtos = await this.produtoRepo.getItems();
            if (produtos == null)
            {
                throw new Exception("Não existem produtos...");
            }

            var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
            return Ok(carrinhoItensDto);
        }
        catch (Exception ex)
        {
            logger.LogError("## Erro ao obter itens do carrinho");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShopCar_DTO>> GetItem(int id)
    {
        try
        {
            var carrinhoItem = await carShopRepo.GetShopItems(id);
            if (carrinhoItem == null)
            {
                return NotFound($"Item não encontrado"); //404 status code
            }

            var produto = await produtoRepo.getItem(carrinhoItem.productId);

            if (produto == null)
            {
                return NotFound($"Item não existe na fonte de dados");
            }
            var cartItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);

            return Ok(cartItemDto);
        }
        catch (Exception ex)
        {
            logger.LogError($"## Erro ao obter o item = {id} do carrinho");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ShopCar_DTO>> PostItem([FromBody]
    ShopCarItemsAdd_DTO carrinhoItemAdicionaDto)
    {
        try
        {
            var novoCarrinhoItem = await carShopRepo.AddShopItems(carrinhoItemAdicionaDto);

            if (novoCarrinhoItem == null)
            {
                return NoContent(); //Status 204
            }

            var produto = await produtoRepo.getItem(novoCarrinhoItem.productId);

            if (produto == null)
            {
                throw new Exception($"Produto não localizado (Id:({carrinhoItemAdicionaDto.productId})");
            }

            var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemParaDto(produto);

            return CreatedAtAction(nameof(GetItem), new { id = novoCarrinhoItemDto.shopCarId },
                novoCarrinhoItemDto);

        }
        catch (Exception ex)
        {
            logger.LogError("## Erro criar um novo item no carrinho");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ShopItems_DTO>> DeleteItem(int id)
    {
        try
        {
            var carrinhoItem = await carShopRepo.DeleteShopItems(id);

            if (carrinhoItem == null)
            {
                return NotFound();
            }

            var produto = await produtoRepo.getItem(carrinhoItem.productId);

            if (produto is null)
                return NotFound();

            var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
            return Ok(carrinhoItemDto);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ShopItems_DTO>> AtualizaQuantidade(int id, 
        ShopItemsUpdate_DTO carrinhoItemAtualizaQuantidadeDto)
    {
        try
        {

            var carrinhoItem = await carShopRepo.UpdateShopItems(id, 
                                   carrinhoItemAtualizaQuantidadeDto);

            if (carrinhoItem == null)
            {
                return NotFound();
            }
            var produto = await produtoRepo.getItem(carrinhoItem.productId);
            var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
            return Ok(carrinhoItemDto);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
