using AuthenticationPlatform.Core.Models;

namespace AuthenticationPlatform.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    public Task AddAsync(User user);
    public Task<User> GetByEmailAsync(string email);
}
