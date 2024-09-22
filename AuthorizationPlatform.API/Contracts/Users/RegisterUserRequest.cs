using System.ComponentModel.DataAnnotations;

namespace AuthorizationPlatform.API.Contracts.Users;

public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Email,
    [Required] string Password);
