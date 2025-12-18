using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application.DTOs.Products;
using ProductsApi.Application.Interfaces;

namespace ProductsApi.API.Controllers;
[Authorize]
[ApiController]
[Route("api/products")]
public class ProductsControllers : ControllerBase
{
    private readonly IProductsService _productsService;
    public ProductsControllers(IProductsService productsService)
    {
        _productsService = productsService;
    }
    [HttpGet]
    public async Task<ActionResult> GetAllProducts()
    {
        var result = await _productsService.GetAllProducts();
        return Ok(result);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult> GetProductById(Guid Id)
    {
        var result = await _productsService.GetProductsById(Id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult> CreateProducts(CreateProductsDto createProductsDto)
    {
        try
        {
            var result = await _productsService.CreateProducts(createProductsDto);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{Id}")]
    public async Task<ActionResult> UpdateProducts(Guid Id, UpdateProductsDto updateProductsDto)
    {
        try
        {
            var result = await _productsService.UpdateProducts(Id, updateProductsDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteProducts(Guid Id)
    {
        var result = await _productsService.DeleteProducts(Id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
