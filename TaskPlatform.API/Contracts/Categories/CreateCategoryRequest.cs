using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.Categories;

public record CreateCategoryRequest(
    [Required] Guid UserId,
    [Required] string Name);