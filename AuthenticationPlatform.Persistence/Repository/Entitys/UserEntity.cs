namespace AuthenticationPlatform.Persistence.Repository.Entitys;

public class UserEntity : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
