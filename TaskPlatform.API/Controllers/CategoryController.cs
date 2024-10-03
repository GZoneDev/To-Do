using Microsoft.AspNetCore.Mvc;
using TaskPlatform.API.Contracts.Categories;
using TaskPlatform.Application.Services;

namespace TaskPlatform.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryRequest createCategoryRequest,
        [FromServices] CategoryService categoryService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await categoryService.AddCategoryAsync(createCategoryRequest.UserId, createCategoryRequest.Name);

        return Ok();
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCategoryRequest updateCategoryRequest,
        [FromServices] CategoryService categoryService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await categoryService.UpdateCategoryAsync(
            updateCategoryRequest.CategoryId,
            updateCategoryRequest.UserId,
            updateCategoryRequest.Name);

        return Ok();
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(
        [FromBody] DeleteCategoryRequest deleteCategoryRequest,
        [FromServices] CategoryService categoryService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await categoryService.DeleteCategoryAsync(deleteCategoryRequest.CategoryId);

        return Ok();
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(
        [FromQuery] GetCategoryRequest getCategoryRequest,
        [FromServices] CategoryService categoryService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await categoryService.GetListByUserAsync(
            getCategoryRequest.UserId,
            getCategoryRequest.Index,
            getCategoryRequest.Number);

        return Ok(result);
    }

    [HttpGet("GetByName")]
    public async Task<IActionResult> GetByName(
        [FromQuery] GetCategoryByNameRequest getCategoryRequest,
        [FromServices] CategoryService categoryService)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await categoryService.GetListByUserAndCategoryNameAsync(
           getCategoryRequest.UserId,
           getCategoryRequest.CategoryName,
           getCategoryRequest.Index,
           getCategoryRequest.Number);

        return Ok(result);
    }
}
