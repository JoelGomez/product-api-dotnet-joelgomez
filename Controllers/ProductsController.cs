using api_restfull_net8.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_restfull_net8.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Product 1",
            Price = 10.0,
            Stock = 100,
            Active = true,
        },
        new Product
        {
            Id = 2,
            Name = "Product 2",
            Price = 20.0,
            Stock = 200,
            Active = true,
        },
        new Product
        {
            Id = 3,
            Name = "Product 3",
            Price = 30.0,
            Stock = 300,
            Active = true,
        },
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return Products;
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<Product> Get(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost(Name = "CreateProduct")]
    public ActionResult<Product> Post([FromBody] Product newProduct)
    {
        if (newProduct == null)
        {
            return BadRequest("Product cannot be null");
        }

        newProduct.Id = Products.Max(p => p.Id) + 1;

        Products.Add(newProduct);

        return CreatedAtRoute("GetProductById", new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}", Name = "UpdateProductById")]
    public ActionResult<Product> Put(int id, [FromBody] Product UpdateProductById)
    {
        if (UpdateProductById == null)
        {
            return BadRequest("Product cannot be null");
        }

        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        product.Price = UpdateProductById.Price;
        product.Name = UpdateProductById.Name;
        product.Stock = UpdateProductById.Stock;
        product.Active = UpdateProductById.Active;

        return Ok(existingProduct);
    }

    [HttpDelete("{id}", Name = "DeleteProductById")]
    public ActionResult<Product> Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        Products.Remove(product);

        return Ok(product);
    }
}
