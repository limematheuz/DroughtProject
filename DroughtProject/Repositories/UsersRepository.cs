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

    public async Task<string> UpdateUsers(Users users)
    {
        var existingUser = await _context.Users.FindAsync(users.Id);
        if (existingUser == null)
        {
            return $"{users.Id}not Found";
        }

        _context.Entry(existingUser).CurrentValues.SetValues(users);
        await _context.SaveChangesAsync();
        return $"User Id ({users.Id}) changed!";
    }

    public async Task<bool> ExistUser(int id)
    {
        return await _context.Users.AnyAsync(x => x.Id == id);
    }

    public async Task<string> DeleteUsers(int id)
    {
        await _context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
        return $"User Id ({id}) deleted! ";
    }
}