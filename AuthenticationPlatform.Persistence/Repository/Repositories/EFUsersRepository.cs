using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AuthenticationPlatform.Core.Models;
using AuthenticationPlatform.Application.Interfaces.Repositories;
using AuthenticationPlatform.Persistence.Repository.Entitys;

namespace AuthenticationPlatform.Persistence.Repository.Repositories;

public class EFUsersRepository : IUsersRepository
{
    private readonly UserDbContext _context;
    private readonly IMapper _mapper;
    public EFUsersRepository(IMapper mapper, UserDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        var userEntity = _mapper.Map<UserEntity>(user);

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);

        return _mapper.Map<User>(userEntity);
    }
}