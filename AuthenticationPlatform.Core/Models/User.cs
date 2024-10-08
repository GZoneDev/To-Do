﻿namespace AuthenticationPlatform.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    private User(Guid id, string userName, string email, string passwordHash)
    {
        Id = id;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static User Create(Guid id, string userName, string email, string passwordHash)
    {
        return new User(id, userName, email, passwordHash);    
    }
}
