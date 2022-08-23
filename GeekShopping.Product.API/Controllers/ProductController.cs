using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _repos;

        public ProductController(IProductRepository repos)
        {
            _repos = repos ?? throw new ArgumentNullException(nameof(repos));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductVO>), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAllProducts()
        {
            var products = await _repos.GetAllProducts();
            if (products == null)
                return NotFound("Nenhum produto cadastrado!");

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductVO>> GetProductById(long id)
        {
            var products = await _repos.GetProductByID(id);
            if (products == null)
                return NotFound("Produto não encontrado!");

            return Ok(products);
        }

        //[HttpGet("SearchCategory/{categoryName}")]
        //[ProducesResponseType(typeof(ProductVO), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<ProductVO>> GetProductByCategoryName(string categoryName)
        //{
        //    var products = await _repos.GetProductByCategoryName(categoryName);
        //    if (products == null)
        //        return NotFound("Produto não encontrado!");

        //    return Ok(products);
        //}

        //[HttpGet("SearchName/{name}")]
        //[ProducesResponseType(typeof(ProductVO), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<ProductVO>> GetProductByName(string name)
        //{
        //    var products = await _repos.GetProductByName(name);
        //    if (products == null)
        //        return NotFound("Produto não encontrado!");

        //    return Ok(products);
        //}

        [HttpPost]
        [ProducesResponseType(typeof(ProductVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var products = await _repos.Create(productVO);
            return Ok(products);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var products = await _repos.Update(productVO);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(long id)
        {

            var status = await _repos.Delete(id);
            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
