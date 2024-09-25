using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.TaskInfos;

public record CreateTaskInfoRequest(
    [Required] Guid CategoryId,
    [Required] string Name,
    [Required] string Description);