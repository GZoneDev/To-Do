using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskPlatform.Application.Interfaces.Repositories;
using TaskPlatform.Core.Models;
using TaskPlatform.Persistence.Repository.Entitys;

namespace TaskPlatform.Persistence.Repository.Repositories;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly TaskDbContext _context;
    private readonly IMapper _mapper;

    public EFCategoryRepository(IMapper mapper, TaskDbContext contex)
    {
        _mapper = mapper;
        _context = contex;
    }
    public async Task AddAsync(Category category)
    {
        var categoryEntity = _mapper.Map<CategoryEntity>(category);

        await _context.Categories.AddAsync(categoryEntity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Category category)
    {
        var categoryEntity = _mapper.Map<CategoryEntity>(category);

        _context.Categories.Update(categoryEntity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid categoryId)
    {
        var categoryEntity = await _context.Categories.FindAsync(categoryId);

        if (categoryEntity is not null)
        {
            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Category[]> GetListByUserAsync(Guid userId, int index, int number)
    {
        var categorieEntities = await _context.Categories
            .Where(c => c.UserId == userId)       
            .OrderBy(c => c.Name)                 
            .Skip(index * number)                 
            .Take(number)                         
            .ToArrayAsync();

        var categories = _mapper.Map<Category[]>(categorieEntities);

        return categories;                        
    }
}
