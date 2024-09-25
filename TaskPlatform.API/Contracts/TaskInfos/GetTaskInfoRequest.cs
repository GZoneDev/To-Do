using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.TaskInfos;

public record GetTaskInfoRequest(
    [Required] Guid CategoryId,
    [Required] int Index,
    [Required] int Number);