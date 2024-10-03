using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.Categories;

public record GetCategoryByNameRequest(
    [Required] Guid UserId,
    [Required] string CategoryName,
    [Required] int Index,
    [Required] int Number);
