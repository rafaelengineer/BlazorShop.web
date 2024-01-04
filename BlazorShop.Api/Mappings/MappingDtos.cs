using BlazorShop.Api.Entities;
using BlazorShop.Model.DTO_s;

namespace BlazorShop.Api.Mappings
{
    public static class MappingDtos
    {

        public static IEnumerable<Category_DTO> ConverterCategoriasParaDto(
                                                this IEnumerable<Category> categorias)
        {
            return (from categoria in categorias
                    select new Category_DTO
                    {
                        categoryId = categoria.categoryId,
                        Name = categoria.Name,
                        IconCSS = categoria.IconCSS
                    }).ToList();
        }
        public static IEnumerable<Product_DTO> ConverterProdutosParaDto(
                                             this IEnumerable<Product> produtos)
        {
            return (from produto in produtos
                    select new Product_DTO
                    {
                        productId = produto.productId,
                        Name = produto.Name,
                        Description = produto.Description,
                        Manufacturer = produto.Manufacturer,
                        Price = produto.Price,
                        qtdInStock = produto.qtdInStock,
                        CategoryId = produto.Category.categoryId,
                        CategoryName = produto.Category.Name
                    }).ToList();
        }
        public static Product_DTO ConverterProdutoParaDto(this Product produto)
        {
            return new Product_DTO
            {
                productId = produto.productId,
                Name = produto.Name,
                Description = produto.Description,
                Manufacturer = produto.Manufacturer,
                Price = produto.Price,
                qtdInStock = produto.qtdInStock,
                CategoryId = produto.Category.categoryId,
                CategoryName = produto.Category.Name
            };
        }

        public static IEnumerable<ShopItems_DTO> ConverterCarrinhoItensParaDto(
            this IEnumerable<shopItems> carrinhoItens, IEnumerable<Product> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.productId equals produto.productId
                    select new ShopItems_DTO
                    {
                        shopItemsId = carrinhoItem.shopItemsId,
                        productId = produto.productId,
                        shopCarId = carrinhoItem.carId,
                        qtd = carrinhoItem.qtd,
                        ProductName = produto.Name,
                        ProductDescription = produto.Description,
                        Price = produto.Price,
                        PriceTotal = produto.Price * carrinhoItem.qtd
                    }).ToList();
        }

        public static ShopItems_DTO ConverterCarrinhoItemParaDto(this shopItems carrinhoItem,
                                                   Product produto)
        {
            return new ShopItems_DTO
            {
                shopItemsId = carrinhoItem.shopItemsId,
                productId = carrinhoItem.productId,
                shopCarId = carrinhoItem.carId,
                qtd = carrinhoItem.qtd,
                ProductName = produto.Name,
                ProductDescription = produto.Description,
                Price = produto.Price,
                PriceTotal = 0
            };

        }
    }
}
