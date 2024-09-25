using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.TaskInfos;

public record UpdateTaskInfoRequest(
    [Required] Guid TaskId,
    [Required] Guid CategoryId,
    [Required] string Name,
    [Required] string Description);