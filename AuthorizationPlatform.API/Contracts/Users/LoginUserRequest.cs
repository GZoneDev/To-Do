using System.ComponentModel.DataAnnotations;

namespace AuthorizationPlatform.API.Contracts.Users;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
