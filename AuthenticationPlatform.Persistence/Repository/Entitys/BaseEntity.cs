namespace AuthenticationPlatform.Persistence.Repository.Entitys;

public class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreationDate { get; set; }
}
