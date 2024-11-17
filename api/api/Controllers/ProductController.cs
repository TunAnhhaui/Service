using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context=context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] ProductDto productDto)
        {
            if (string.IsNullOrEmpty(productDto.Name))
            {
                return BadRequest("Tên sản phẩm không được để trống");
            }
            if (productDto.CategoryId==null || productDto.CategoryId<=0)
            {
                return BadRequest("Vui lòng chọn thể loại sản phẩm");
            }
            if (productDto.Price == null || productDto.Price <= 0)
            {
                return BadRequest("Vui lòng nhập giá sản phẩm");
            }
            if (string.IsNullOrEmpty(productDto.Image))
            {
                return BadRequest("Vui lòng chọn ảnh cho sản phẩm");
            }

            var newProduct = new Product
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price,
                Image = productDto.Image,
                Description = productDto.Description,
                CreatedDate = DateTime.Now
            };
            if (productDto.Discounted.HasValue && productDto.Discounted > 0)
            {
                newProduct.Discounted = productDto.Discounted;
                newProduct.DiscountedPrice = newProduct.Price - (newProduct.Price * (productDto.Discounted.Value / 100));
            }
            else
            {
                newProduct.Discounted = null; 
                newProduct.DiscountedPrice = null; 
            }
            _context.products.Add(newProduct);
            await _context.SaveChangesAsync();
            return Ok("Thêm mới thành công");
        }
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> update([FromBody] ProductDto productDto,int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name= productDto.Name;
            product.Description= productDto.Description;
            product.Price= productDto.Price;
            product.Image= productDto.Image;
            product.Discounted = productDto.Discounted;
            product.CategoryId = productDto.CategoryId;
            product.CreatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("getByPage")]
        public async Task<IActionResult> getByPage(int page=1,int limit=4, string? sort = null, int? maxPrice = null, int? minPrice = null, string? size = null, string? color = null)
        {
            var query = _context.products.AsQueryable();
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(size))
            {
                query = query.Where(p => p.ProductSizes.Any(ps => ps.Size.Name == size));
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(p => p.ProductColors.Any(pc => pc.Color.Name == color));
            }
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "price_asc":
                        query = query.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "new":
                        query = query.OrderByDescending(p => p.CreatedDate); ;
                        break;
                    default:
                        break;
                }
            }
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / limit);
            var products = await query
                .Include(c => c.Comments)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.DiscountedPrice,
                product.Sell,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                  ? product.Comments.Average(c => (double)c.Rate)
                  : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();
            return Ok(new
            {
                TotalPages = totalPages,
                CurrentPage = page,
                Products = result
            });
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var products = await _context.products
                .Include(p=>p.ProductImages)
                .Include(p=>p.Comments)
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                   ? product.Comments.Average(c => (double)c.Rate)
                   : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();
            return Ok(result);
        }
        [HttpGet("getNew")]
        public async Task<IActionResult> getNew()
        {
            var products = await _context.products
                .Include(p=>p.Comments)
                .OrderByDescending(p => p.CreatedDate)
                .Take(4) 
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.DiscountedPrice,
                product.Sell,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                  ? product.Comments.Average(c => (double)c.Rate)
                  : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();
            return Ok(result);
        }
        [HttpGet("getDiscount")]
        public async Task<IActionResult> getDiscount()
        {
            var products = await _context.products
                .Include(c=>c.Comments)
                .Where(p => p.Discounted.HasValue && p.Discounted > 0)
                .OrderBy(p => Guid.NewGuid())
                .Take(8)
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.DiscountedPrice,
                product.Sell,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                  ? product.Comments.Average(c => (double)c.Rate)
                  : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();
            return Ok(result);
        }

        [HttpGet("sell")]
        public async Task<IActionResult> getSell()
        {
            var products = await _context.products
                .Include(c => c.Comments)
                .OrderByDescending(p => p.Sell)
                .Take(8)
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.DiscountedPrice,
                product.Sell,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                  ? product.Comments.Average(c => (double)c.Rate)
                  : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();
            return Ok(result);
        }
        [HttpGet("getOne/{id}")]
        public async Task<IActionResult> getOne(int id)
        {
            var product=await _context.products
                .Include(p=>p.Category)
                .Include(c=>c.ProductImages)
                .Include(c=>c.ProductSizes)
                .ThenInclude(pc => pc.Size)
                .Include(c=>c.ProductColors)
                .ThenInclude(pc => pc.Color)
                .Include(pc=>pc.Comments)
                .ThenInclude(pc=>pc.User)
                .FirstOrDefaultAsync(x=>x.ProductId==id);
            return Ok(product);
        }
        [HttpGet("getByCategory/{categoryId}")]
        public async Task<IActionResult> getByCategory(int categoryId,int page=1,int limit=4, string? sort = null, int? maxPrice = null, int? minPrice = null, string? size = null, string? color = null)
        {
            var query = _context.products.AsQueryable().Where(p => p.CategoryId == categoryId);
            if(minPrice.HasValue)
            {
                query=query.Where(p=>p.Price>=minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(size))
            {
                query = query.Where(p => p.ProductSizes.Any(ps => ps.Size.Name == size));
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(p => p.ProductColors.Any(pc=>pc.Color.Name == color)); 
            }
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "price_asc":
                        query = query.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "new":
                        query = query.OrderByDescending(p => p.CreatedDate); ;
                        break;
                    default:
                        break;
                }
            }
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / limit);
            var products = await query
                .Include(c=>c.Comments)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.DiscountedPrice,
                product.Sell,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                  ? product.Comments.Average(c => (double)c.Rate)
                  : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();

            var category = await _context.categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            return Ok(new
            {
                category = category,
                TotalPages = totalPages,
                CurrentPage = page,
                Products = result
            });
        }

        [HttpGet("search")]
        public async Task<IActionResult> search(string? q,int page=1,int limit=8)
        {
            var query = _context.products.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.Name.Contains(q));
            }
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / limit);
            var products = await query
                .Include (c=>c.Comments)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
            var result = products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Image,
                product.Description,
                product.Price,
                product.Discounted,
                product.DiscountedPrice,
                product.Sell,
                product.CreatedDate,
                AverageRate = Math.Round(product.Comments.Any()
                 ? product.Comments.Average(c => (double)c.Rate)
                 : 0, 1),
                CommentCount = product.Comments.Count()
            }).ToList();
            return Ok(new
            {
                total = totalItems,
                products = result,
                CurrentPage = page,
                TotalPages=totalPages,
            });
        }
    }
}
