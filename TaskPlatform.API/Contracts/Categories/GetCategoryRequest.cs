using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.Categories;

public record GetCategoryRequest(
    [Required] Guid UserId,
    [Required] int Index,
    [Required] int Number);