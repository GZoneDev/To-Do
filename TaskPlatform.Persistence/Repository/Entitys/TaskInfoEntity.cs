namespace TaskPlatform.Persistence.Repository.Entitys;

public class TaskInfoEntity
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public required CategoryEntity Category { get; set; }
}
