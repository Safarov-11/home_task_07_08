using Dapper;
using Domain.Entities;
using Domain.Entities.DTOs;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class UsersService : IUsersService
{
    private readonly DataContext context = new DataContext();
    public void AddUser(Users user)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            insert into users(fullname, email, phone) 
            values(@fullname, @email, @phone);";
            var result = connection.Execute(cmd,user);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public void DeleteUser(int id)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            delete from users 
            where id = @id";
            var result = connection.Execute(cmd, new {id = id} );
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public List<Users> GetAllUsers()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"select * from users";
            List<Users> result = connection.Query<Users>(cmd).ToList();
            
            return result;
        }
    }

    public void UpdateUsers(Users user)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            update users
            set fullname = @fullname, email = @email, phone = @phone 
            where id = @Id";
            int result = connection.Execute(cmd,user);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public List<Users> GetUserByNameOrEmail(string text){
        using (var connection = context.GetConnection())
        {
            var cmd = @"select * from users
            where fullname like @text or email like @text;";
            var result = connection.Query<Users>(cmd, new {text = $"%{text}%" }).ToList();
            return result;
        }
    }

    public void AddDateTimeToUsers(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"
alter table users 
add column DataCreated date default Current_date;";
            
            var result = connection.Execute(cmd);
            
            System.Console.WriteLine(result==0 ? "Sucssesfuly added column date" : "Failed");
            
        }
    }

    public List<UsersMarketCount> UsersAndMarketsCount(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"
select u.fullname, count(m.id) from markets m
join users u on u.id = m.userId
group by u.fullname";
            
            var result = connection.Query<UsersMarketCount>(cmd).ToList();
            
            return result;
            
        }
    }


}




