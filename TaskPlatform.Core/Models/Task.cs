namespace TaskPlatform.Core.Models;

public class Task
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private Task(Guid id, Guid categoryId, string name, string description)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
    }

    public static Task Create(Guid id, Guid categoryId, string name, string description)
    {
        return new Task(id, categoryId, name, description);
    }
}
