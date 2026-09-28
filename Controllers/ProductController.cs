using Microsoft.AspNetCore.Mvc;
using MojeApiKontrolery.Models;
using MojeApiKontrolery.Services;

[ApiController]
[Route("/api/products")]
public class ProductController : ControllerBase {

    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _productService.GetById(id);

        if (product == null)
        {
            return NotFound(new {Message = $"Product o id {id} nie istnieje"});
        }
        return Ok(product);
        
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] Product newProduct)
    {
        try
        {
             _productService.Add(newProduct);
                return Ok(new {Message = "Produkt dodany pomyślnie!", Product = newProduct});
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new {Message = ex.Message});
        }

    }
}


