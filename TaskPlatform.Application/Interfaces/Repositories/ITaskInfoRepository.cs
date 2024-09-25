using TaskPlatform.Core.Models;

namespace TaskPlatform.Application.Interfaces.Repositories;

public interface ITaskInfoRepository
{
    public Task AddAsync(TaskInfo taskInfo);
    public Task UpdateAsync(TaskInfo taskInfo);
    public Task DeleteByIdAsync(Guid taskInfoId, Guid categoryId);
    public Task<TaskInfo[]> GetListByCategoryIdAsync(Guid categoryId, int index, int number);
}
