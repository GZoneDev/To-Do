namespace TaskPlatform.Persistence.Repository.Entitys;

public class CategoryEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Name { get; set; }

    public required ICollection<TaskInfoEntity> Tasks { get; set; }
}
