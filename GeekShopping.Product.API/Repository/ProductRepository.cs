using AutoMapper;
using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Model.Context;
using Microsoft.EntityFrameworkCore;
using GeekShopping.Product.API.Model;

namespace GeekShopping.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVO> Create(ProductVO product)
        {
            Model.Product prod = _mapper.Map<Model.Product>(product);

            await _context.Products.AddAsync(prod);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);

        }

        public async Task<ProductVO> Update(ProductVO product)
        {

            Model.Product prod = _mapper.Map<Model.Product>(product);

             _context.Products.Update(prod);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);

        }

        public async Task<bool> Delete(long id)
        {

            var result = await _context.Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (result == null)
                return false;


            _context.Products.Remove(result);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<ProductVO>> GetAllProducts()
        {
            List<Model.Product> products = await _context.Products.OrderBy(x => x.CategoryName).AsNoTracking().ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<IEnumerable<ProductVO>> GetProductByCategoryName(string categoryName)
        {
            List<Model.Product> product = await _context.Products.Where(x => x.CategoryName.Equals(categoryName)).AsNoTracking().ToListAsync();
            return _mapper.Map<List<ProductVO>>(product);
        }

        public async Task<ProductVO> GetProductByID(long id)
        {
            Model.Product product = await _context.Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> GetProductByName(string name)
        {
            Model.Product product = await _context.Products.Where(x => x.Name.Equals(name)).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }


    }
}
