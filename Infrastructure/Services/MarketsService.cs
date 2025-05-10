using Dapper;
using Domain.Entities;
using Domain.Entities.DTOs;
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
add column DataCreated date default Current_date;";
            
            var result = connection.Execute(cmd);
            
            System.Console.WriteLine(result==0 ? "Sucssesfuly added column date" : "Failed");
            
        }
    }

    public void CreateNewColumnforUserId(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"alter table Markets
            add column UserId int references users(id) on delete cascade";

            connection.Execute(cmd);

        }
    }
    public void AddUserToMarket(int marketId, int UserId){
        using (var connection = context.GetConnection())
        {
            var cmd2 = @"
            update markets
            set userId = @userId
            where id = @marketId";

            var result = connection.Execute(cmd2, new {userId = UserId, marketId = marketId});
            System.Console.WriteLine(result>0 ? "Sucssesfuly added user to market" : "Failed");
        }
    }

    public SmallestPriceMarket MarketWithSmallesPrices(){
        using (var connection = context.GetConnection())
        {
            var cmd2 = @"select m.name, sum(p.price * p.quantity) as minPrice
                            from products p
                            join markets m on p.marketId = m.id
                            group by m.name
                            order by minPrice asc
                            limit 1";

            SmallestPriceMarket result = connection.QueryFirstOrDefault<SmallestPriceMarket>(cmd2);
            return result;
        }
    }

    public List<Markets> GetNewMarkets(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"select * from markets 
                        where  DataCreated > now() - interval '7 days'";

            var result = connection.Query<Markets>(cmd).ToList();
            return result;
        }
        
    }

    public List<MarketsProductCount> GetMarketsProductCounts(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"select m.name, count(p.id) from products p
join markets m on p.marketId = m.id
group by m.name";

            var result = connection.Query<MarketsProductCount>(cmd).ToList();
            return result;
        }
        
    }
}
