﻿using BlazorShop.Model.DTO_s;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorShop.Web.Services;

public class CarrinhoCompraService : ICarrinhoCompraService
{
    private readonly HttpClient httpClient;
    public CarrinhoCompraService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public event Action<int> OnCarrinhoCompraChanged;

    public async Task<ShopItems_DTO> AdicionaItem(ShopCarItemsAdd_DTO carrinhoItemAdicionaDto)
    {
        try
        {
            var response = await httpClient
                          .PostAsJsonAsync<ShopCarItemsAdd_DTO>("api/CarrinhoCompra",
                           carrinhoItemAdicionaDto);

            if (response.IsSuccessStatusCode)// status code entre 200 a 299
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    // retorna o valor "padrão" ou vazio
                    // para uma objeto do tipo ShopItems_DTO
                    return default(ShopItems_DTO);
                }
                //le o conteudo HTTP e retorna o valor resultante
                //da serialização do conteudo JSON para o objeto Dto
                return await response.Content.ReadFromJsonAsync<ShopItems_DTO>();
            }
            else
            {
                //serializa o conteudo HTTP como uma string
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"{response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<ShopItems_DTO> AtualizaQuantidade(ShopItemsUpdate_DTO
                                                   carrinhoItemAtualizaQuantidadeDto)
    {
        try
        {
            var jsonRequest = JsonSerializer.Serialize(carrinhoItemAtualizaQuantidadeDto);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

            var response = await httpClient.PatchAsync($"api/CarrinhoCompra/{carrinhoItemAtualizaQuantidadeDto.shopItemsId}", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ShopItems_DTO>();
            }
            return null;
        }
        catch (Exception)
        {
            throw;
        }

    }
    public async Task<ShopItems_DTO> DeleteItem(int id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"api/CarrinhoCompra/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ShopItems_DTO>();
            }
            return default(ShopItems_DTO);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<ShopItems_DTO>> GetItens(string usuarioId)
    {
        try
        {
            //envia um request GET para a uri da API CarrinhoCompra
            var response = await httpClient.GetAsync($"api/CarrinhoCompra/{usuarioId}/GetItens");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ShopItems_DTO>().ToList();
                }
                return await response.Content.ReadFromJsonAsync<List<ShopItems_DTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade)
    {
        if (OnCarrinhoCompraChanged != null)
        {
            OnCarrinhoCompraChanged.Invoke(totalQuantidade);
        }
    }
}