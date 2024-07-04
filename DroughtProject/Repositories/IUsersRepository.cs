using DroughtProject.Models;

namespace DroughtProject.Repositories;

public interface IUsersRepository
{
    Task<List<Users>> GetAllUsers();
    Task<int> CreateUsers(Users users);
    Task<int> UpdateUsers(Users users);
    Task<bool> ExistUser(int id);

}