using TaskPlatform.Application.Interfaces.Repositories;
using TaskPlatform.Core.Models;

namespace TaskPlatform.Application.Services;

public class CategoryService
{   
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task AddCategoryAsync(Guid userId, string categoryName)
    {
        var newCategory = Category.Create(Guid.NewGuid(), userId, categoryName);

        await _categoryRepository.AddAsync(newCategory);
    }

    public async Task UpdateCategoryAsync(Guid categoryId, Guid userId, string categoryName)
    {
        var category = Category.Create(categoryId, userId, categoryName);

        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid categoryId)
    {
        await _categoryRepository.DeleteByIdAsync(categoryId);
    }

    public async Task<Category[]> GetListByUserAsync(Guid userId, int index, int number)
    {
        return await _categoryRepository.GetListByUserAsync(userId, index, number);
    }
}
