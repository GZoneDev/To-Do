using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskPlatform.Application.Interfaces.Repositories;
using TaskPlatform.Core.Models;
using TaskPlatform.Persistence.Repository.Entitys;

namespace TaskPlatform.Persistence.Repository.Repositories;

public class EFTaskInfoRepository : ITaskInfoRepository
{
    private readonly TaskDbContext _context;
    private readonly IMapper _mapper;

    public EFTaskInfoRepository(IMapper mapper, TaskDbContext contex)
    {
        _mapper = mapper;
        _context = contex;
    }
    public async Task AddAsync(TaskInfo taskInfo)
    {
        var taskInfoEntity = _mapper.Map<TaskInfoEntity>(taskInfo);

        await _context.Tasks.AddAsync(taskInfoEntity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(TaskInfo taskInfo)
    {
        var taskInfoEntity = _mapper.Map<TaskInfoEntity>(taskInfo);

        _context.Tasks.Update(taskInfoEntity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid taskInfoId, Guid categoryId)
    {
        var taskInfoEntity = await _context.Tasks.FindAsync(taskInfoId);

        if (taskInfoEntity is not null)
        {
            _context.Tasks.Remove(taskInfoEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TaskInfo[]> GetListByCategoryIdAsync(Guid categoryId, int index, int number)
    {
        var taskEntities = await _context.Tasks
            .Where(t => t.CategoryId == categoryId)
            .OrderBy(t => t.Name)
            .Skip(index * number)
            .Take(number)
            .ToArrayAsync();

        var taskInfoList = _mapper.Map<TaskInfo[]>(taskEntities);

        return taskInfoList;
    }
}
