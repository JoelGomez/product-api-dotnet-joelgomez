using api_restfull_net8.Data;
using api_restfull_net8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapi_net8.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    //GET: /products
    //GET: /products/{id}
    //POST: /products
    //PUT: /products/{id}
    //DELETE: /products/{id}

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> Get()
    {
        var products = await _context.Products.ToListAsync();

        var productDtos = products.Select(p => new ProductReadDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
        });

        return Ok(productDtos);
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ProductReadDto>> Get(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var productDto = new ProductReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };

        return Ok(productDto);
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<ProductReadDto>> Post([FromBody] ProductCreateDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock,
            Active = productDto.Active,
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var ProductReadDto = new ProductReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };

        return CreatedAtRoute("GetProductById", new { id = product.Id }, ProductReadDto);
    }

    [HttpPut("{id}", Name = "UpdateProductById")]
    public async Task<ActionResult> Put(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest("Product ID mismatch");
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(p => p.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return Ok("Product updated successfully");
    }

    [HttpDelete("{id}", Name = "DeleteProductById")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok("Product deleted successfully");
    }
}
