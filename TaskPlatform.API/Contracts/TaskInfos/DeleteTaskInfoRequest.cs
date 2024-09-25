using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.API.Contracts.TaskInfos;

public record DeleteTaskInfoRequest(
    [Required] Guid TaskId,
    [Required] Guid CategoryId);