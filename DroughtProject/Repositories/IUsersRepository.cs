using DroughtProject.Models;

namespace DroughtProject.Repositories;

public interface IUsersRepository
{
    Task<List<Users>> GetAllUsers();
}