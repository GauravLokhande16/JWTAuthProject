using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody]ProductDto product)
        {
            if(product == null)
            {
                return BadRequest("Body is null");
            }
            Product model = new()
            { 
                Colour = product.Colour, 
                Description= product.Description, 
                Name= product.Name,
                Price= product.Price,
                ProductId= product.ProductId,
                CreatedDate= DateTime.Now,
             };
            _context.Products.Add(model);
            _context.SaveChanges();
            return Ok();
        }
    }
}
