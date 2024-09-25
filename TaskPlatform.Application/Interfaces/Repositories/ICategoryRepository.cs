using TaskPlatform.Core.Models;

namespace TaskPlatform.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    public Task AddAsync(Category category);
    public Task UpdateAsync(Category category);
    public Task DeleteByIdAsync(Guid categoryId);
    public Task<Category[]> GetListByUserAsync(Guid userId, int index, int number);
}
