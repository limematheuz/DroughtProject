using DroughtProject.Models;

namespace DroughtProject.Repositories;

public interface IUsersRepository
{
    Task<List<Users>> GetAllUsers();
    Task<int> CreateUsers(Users users);
    Task<string> UpdateUsers(Users users);
    Task<bool> ExistUser(int id);
    Task<string> DeleteUsers(int id);

}