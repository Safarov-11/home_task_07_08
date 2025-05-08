using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class MarketsService : IMarketsService
{
    private readonly DataContext context = new DataContext();
    public void AddMarket(Markets market)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            insert into markets(Name, Address) 
            values(@Name, @Address);";
            var result = connection.Execute(cmd,market);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public void DeleteMarket(int id)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            delete from markets 
            where id = @id";
            var result = connection.Execute(cmd, new {id = id} );
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public List<Markets> GetAllMarkets()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"select * from markets";
            List<Markets> result = connection.Query<Markets>(cmd).ToList();
            
            return result;
        }
    }

    public void UpdateMarkets(Markets market)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            update markets
            set Name = @Name, Address = @address 
            where id = @Id";
            int result = connection.Execute(cmd,market);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public void AddDateTimeToMarket(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"
alter table markets 
add column DataCreated default Current_date;";
            
            var result = connection.Execute(cmd);
            
            System.Console.WriteLine(result==0 ? "Sucssesfuly added column date" : "Failed");
            
        }
    }
}
