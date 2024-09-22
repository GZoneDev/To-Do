namespace TaskPlatform.Persistence.Repository.Entitys;

public class CategoryEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }

    public ICollection<TaskEntity> Tasks { get; set; }
}
