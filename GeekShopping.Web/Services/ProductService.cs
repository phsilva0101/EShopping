using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _client.PostAsJson(BasePath, product);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception("Alguma coisa deu errado na chamada da API!");
        }

        public async Task<bool> DeleteProduct(long id)
        {

            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Alguma coisa deu errado na chamada da API!");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {

            var response = await _client.PutAsJson(BasePath, product);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception("Alguma coisa deu errado na chamada da API!");
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProductByCategoryName(string categoryName)
        {
            var response = await _client.GetAsync($"{BasePath}/{categoryName}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> GetProductByID(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> GetProductByName(string name)
        {
            var response = await _client.GetAsync($"{BasePath}/{name}");
            return await response.ReadContentAs<ProductModel>();
        }

      
    }
}
