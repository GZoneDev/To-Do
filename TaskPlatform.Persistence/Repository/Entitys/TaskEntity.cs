namespace TaskPlatform.Persistence.Repository.Entitys;

public class TaskEntity
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public CategoryEntity Category { get; set; }
}
