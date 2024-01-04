using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Model.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProductRepository _produtoRepository;

    public ProdutosController(IProductRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_DTO>>> GetItems()
    {
        try
        {
            var produtos = await _produtoRepository.getItems();
            if (produtos is null)
            {
                return NotFound();
            }
            else
            {
                var produtoDtos = produtos.ConverterProdutosParaDto();
                return Ok(produtoDtos);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados " + Environment.NewLine + e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product_DTO>> GetItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.getItem(id);
            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }
            else
            {
                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados " + Environment.NewLine + e.Message);
        }
    }

    [HttpGet]
    [Route("{categoriaId}/GetItensPorCategoria")]
    public async Task<ActionResult<IEnumerable<Product_DTO>>>
        GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var produtos = await _produtoRepository.getItemsByCatgory(categoriaId);
            var produtosDto = produtos.ConverterProdutosParaDto();
            return Ok(produtosDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Erro ao acessar o banco de dados");
        }
    }

    [HttpGet]
    [Route("GetCategorias")]
    public async Task<ActionResult<IEnumerable<Category_DTO>>> GetCategorias()
    {
        try
        {
            var categorias = await _produtoRepository.getCategories();
            var categoriasDto = categorias.ConverterCategoriasParaDto();
            return Ok(categoriasDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                       "Erro ao acessar o banco de dados");
        }
    }
}
