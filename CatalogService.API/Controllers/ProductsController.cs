// CatalogService.API/Controllers/ProductsController.cs
using CatalogService.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        // We will replace this with a database call later!
        var products = new List<Product>
        {
            new Product { Name = "Mechanical Keyboard", Price = 120.50m, StockQuantity = 15 },
            new Product { Name = "Wireless Mouse", Price = 45.99m, StockQuantity = 30 }
        };

        return Ok(products);
    }
}