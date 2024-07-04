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
}