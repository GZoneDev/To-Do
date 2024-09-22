namespace TaskPlatform.Core.Models;

public class Category
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    private Category(Guid id, Guid userId, string name)
    {
        Id = id;
        UserId = userId;
        Name = name;
    }

    public static Category Create(Guid id, Guid userId, string name)
    {
        return new Category(id, userId, name);
    }
}
