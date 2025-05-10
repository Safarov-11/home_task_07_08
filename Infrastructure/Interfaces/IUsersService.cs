using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IUsersService
{
    void AddUser(Users user);
    List<Users> GetAllUsers();
    void UpdateUsers(Users user);
    void DeleteUser(int id);
    List<Users> GetUserByNameOrEmail(string text);
    void AddDateTimeToUsers();
}
