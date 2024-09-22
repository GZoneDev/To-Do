using AuthenticationPlatform.Core.Models;

namespace AuthenticationPlatform.Application.Interfaces.Auth;

public interface ITokenProvider
{
    public string GenerateToken(User user);
}
