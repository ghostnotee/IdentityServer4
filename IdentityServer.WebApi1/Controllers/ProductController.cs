using IdentityServer.WebApi1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.WebApi1.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    [Authorize(Policy = "ReadProduct")]
    [HttpGet]
    public IActionResult GetProduct()
    {
        List<Product> products = new()
        {
            new Product { Id = 1, Name = "Çok acayip Product", Price = 10000, Stock = 100 },
            new Product { Id = 2, Name = "İnanılmaz derecede iyi Product", Price = 15000, Stock = 100 },
            new Product { Id = 3, Name = "Böylesini bulamazsın Product", Price = 13000, Stock = 100 }
        };

        return Ok(products);
    }

    [Authorize(Policy = "UpdateOrCreate")]
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id)
    {
        return Ok($"{id} product updated");
    }

    [Authorize(Policy = "UpdateOrCreate")]
    [HttpPost]
    public IActionResult CreateProduct()
    {
        return Ok("product created");
    }
}