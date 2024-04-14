using E_Commerce.Models.Dto;

namespace E_Commerce.Data
{
    public static class ProductStore
    {
        public static List<ProductDto> productList = new List<ProductDto>()
            {
                new ProductDto{ ProductId = 1, Name = "cycle", Colour = "blcak", Description = "Still", Price = 7000 },
                new ProductDto{ ProductId = 2, Name = "cycle", Colour = "blcak", Description = "Still", Price = 7000 },
            };
    }
}
