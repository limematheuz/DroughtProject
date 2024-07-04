using DroughtProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DroughtProject.Data;

public class ApplicationDbContext (DbContextOptions options) : DbContext (options)
{
    public DbSet<Users> Users { get; set; }
}