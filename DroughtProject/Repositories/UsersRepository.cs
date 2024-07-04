using DroughtProject.Data;
using DroughtProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DroughtProject.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Users>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<int> CreateUsers(Users users)
    {
        _context.Add(users);
        await _context.SaveChangesAsync();
        return users.Id;
    }

    public async Task<int> UpdateUsers(Users users)
    {
        await _context.Users.FindAsync(users.Id);
        await _context.SaveChangesAsync();
        return users.Id;
    }

    public async Task<bool> ExistUser(int id)
    {
        return await _context.Users.AnyAsync(x => x.Id == id);
    }
}