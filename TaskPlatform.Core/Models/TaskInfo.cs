namespace TaskPlatform.Core.Models;

public class TaskInfo
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private TaskInfo(Guid id, Guid categoryId, string name, string description)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
    }

    public static TaskInfo Create(Guid id, Guid categoryId, string name, string description)
    {
        return new TaskInfo(id, categoryId, name, description);
    }
}
