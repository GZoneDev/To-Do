using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.Categories;

public record UpdateCategoryRequest(
    [Required] Guid UserId,
    [Required] Guid CategoryId,
    [Required] string Name);