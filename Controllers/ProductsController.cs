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
}
