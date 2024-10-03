using TaskPlatform.Application.Interfaces.Repositories;
using TaskPlatform.Core.Models;

namespace TaskPlatform.Application.Services;

public class TaskInfoService
{
    private readonly ITaskInfoRepository _taskInfoRepository;

    public TaskInfoService(ITaskInfoRepository categoryRepository)
    {
        _taskInfoRepository = categoryRepository;
    }

    public async Task AddTaskInfoAsync(Guid categoryId, string name, string description)
    { 
        var taskInfo = TaskInfo.Create(Guid.NewGuid(), categoryId, name, description);

        await _taskInfoRepository.AddAsync(taskInfo);
    }

    public async Task UpdateTaskInfoAsync(Guid taskInfoId, Guid categoryId, string name, string description)
    {
        var taskInfo = TaskInfo.Create(taskInfoId, categoryId, name, description);

        await _taskInfoRepository.UpdateAsync(taskInfo);
    }

    public async Task DeleteTaskInfo(Guid taskInfoId, Guid categoryId)
    {
        await _taskInfoRepository.DeleteByIdAsync(taskInfoId, categoryId);
    }

    public async Task<TaskInfo[]> GetListByCategoryAsync(Guid categoryId, int index, int number)
    {
        return await _taskInfoRepository.GetListByCategoryIdAsync(categoryId, index, number);
    }
}
