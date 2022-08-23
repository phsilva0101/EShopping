using GeekShopping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Repository
{
    public interface IProductRepository
    {
        public Task <IEnumerable< ProductVO>> GetAllProducts();
        public Task <ProductVO> GetProductByID(long id);
        public Task<ProductVO> GetProductByName(string name);
        public Task<IEnumerable<ProductVO>> GetProductByCategoryName(string categoryName);
        public Task<ProductVO> Create(ProductVO product);
        public Task<bool> Delete(long id);
        public Task<ProductVO> Update(ProductVO product);
    }
}
