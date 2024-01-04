using BlazorShop.Model.DTO_s;
using System.Net;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services;

public class ProdutoService : IProdutoService
{
    public HttpClient _httpClient;
    public ILogger<ProdutoService> _logger;

    public ProdutoService(HttpClient httpClient,
        ILogger<ProdutoService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<Product_DTO>> GetItens()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Produtos");

            if (response.IsSuccessStatusCode)
            {
                var produtosDto = await response.Content.ReadFromJsonAsync<IEnumerable<Product_DTO>>();
                return produtosDto;
            }
            else
            {
                _logger.LogError($"Error accessing products: api/Produtos, Status Code: {response.StatusCode}");
                // Handle non-success status code if needed
                throw new Exception();
            }
        }
        catch (Exception e)
        {
            _logger.LogError("Error accessing products: api/Produtos", e);
            Console.WriteLine("Exception message: " + e.Message);
            Console.WriteLine("Exception source: " + e.Source);
            throw;
        }
    }

    public async Task<Product_DTO> GetItem(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/produtos/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(Product_DTO);
                }
                return await response.Content.ReadFromJsonAsync<Product_DTO>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro a obter produto pelo id= {id} - {message}");
                throw new Exception($"Status Code : {response.StatusCode} - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Erro a obter produto pelo id={id}");
            throw;
        }
    }

    public async Task<IEnumerable<Category_DTO>> GetCategorias()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Produtos/GetCategorias");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Category_DTO>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Category_DTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            //log exception
            throw;
        }
    }

    public async Task<IEnumerable<Product_DTO>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Produtos/{categoriaId}/GetItensPorCategoria");
            
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Product_DTO>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Product_DTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            //log exception
            throw;
        }
    }

}
