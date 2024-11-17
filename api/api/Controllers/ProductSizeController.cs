using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductSizeController : Controller
    {
        private readonly AppDbContext _context;
        public ProductSizeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] ProductSizeDto productSizeDto)
        {
            var productSize = await _context.productSizes
                .Where(
                z => z.ProductId == productSizeDto.ProductId
                && z.SizeId==productSizeDto.SizeId).SingleOrDefaultAsync();
            if (productSize != null)
            {
                productSize.Price = productSizeDto.Price;
                if (productSizeDto.Discounted.HasValue && productSizeDto.Discounted > 0)
                {
                    productSize.Discounted = productSizeDto.Discounted;
                    productSize.DiscountedPrice = productSizeDto.Price - (productSizeDto.Price * (productSizeDto.Discounted.Value / 100));
                }
                else
                {
                    productSize.Discounted = null;
                    productSize.DiscountedPrice = null;
                }
                _context.productSizes.Update(productSize);
            }
            else
            {
                var newProductSize = new ProductSize
                {
                    ProductId = productSizeDto.ProductId,
                    SizeId = productSizeDto.SizeId,
                    Price = productSizeDto.Price,
                };
                if (productSizeDto.Discounted.HasValue && productSizeDto.Discounted > 0)
                {
                    newProductSize.Discounted = productSizeDto.Discounted;
                    newProductSize.DiscountedPrice = newProductSize.Price - (newProductSize.Price * (productSizeDto.Discounted.Value / 100));
                }
                else
                {
                    newProductSize.Discounted = null;
                    newProductSize.DiscountedPrice = null;
                }
                _context.productSizes.Add(newProductSize);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
