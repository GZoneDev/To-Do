using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.Categories;

public record DeleteCategoryRequest(
    [Required] Guid CategoryId);