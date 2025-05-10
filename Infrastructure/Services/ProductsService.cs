using Dapper;
using Domain.Entities;
using Domain.Entities.DTOs;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ProductsService : IProductsService
{
    private readonly DataContext context = new DataContext(); 
    public string AddProduct(Products product)
    {
        using (var connection = context.GetConnection())
        {
            var com = @"select * from markets where id = @MarketId";
            var market = connection.QueryFirstOrDefault<Markets>(com, product);
            if (market == null)
            {
                return "Market doesn't exist";
            } 

            var cmd = @"
            insert into products(Name,Price,CategoryId,MarketId,Quantity)
            values(@Name,@Price,@CategoryId,@MarketId,@Quantity)";

            var result = connection.Execute(cmd,product);
            return result>0 ? "Sucsses" : "Failed";
        }
    }

    public string DeleteProduct(int id)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"delete from products 
            where id = @id";
            var result = connection.Execute(cmd, new { id = id } );
            return result>0 ? "Sucsses" : "Failed";
        }
    }

    public List<Products> GetAllProducts()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"select * from products";
            List<Products> result = connection.Query<Products>(cmd).ToList();
            return result;
        }
    }

    public string UpdateProducts(Products product)
    {
        using (var connection = context.GetConnection())
        {
            var com = @"select * from markets where id = @MarketId";
            var market = connection.QueryFirstOrDefault<Markets>(com, product);
            if (market == null)
            {
                return "Market doesn't exist";
            } 
            var cmd = @"update products 
            set name = @name, price = @price, categoryId = @categoryId, marketId = @marketId, quantity = @quantity
            where id = @id";
            var result = connection.Execute(cmd,product);
            return result>0 ? "Sucsses" : "Failed";

        }
    }

    public List<ProductInfoDTO> GetProductInfo(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"
select p.name, c.name, m.name from products p
join category c on c.id = p.categoryId
join markets m on m.id = p.marketId";
            List<ProductInfoDTO> result = connection.Query<ProductInfoDTO>(cmd).ToList();
            
            return result;
        }
    }

    public void AddDateTimeToProducts(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"
alter table products 
add column DataCreated date default Current_date;";
            
            var result = connection.Execute(cmd);
            
            System.Console.WriteLine(result==0 ? "Sucssesfuly added column date" : "Failed");
            
        }
    }

    public void UpdatePricesByCategoryId(int CategoryId, int percentage)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
update products
set price =  price + ((price * @percentage)/100)
where categoryId = @categoryId";

            var anonymProd = new {categoryId = CategoryId, percentage = percentage };
            var result = connection.Execute(cmd, anonymProd);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public List<SumPriceProdsDTO> GetSumPriceOfProductsByMarketId()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
select p.name, m.name, sum(P.PRICE * p.quantity) 
from products p 
join markets m on m.id =p.marketId
group By p.name, m.name";

            
            var result = connection.Query<SumPriceProdsDTO>(cmd).ToList();
           return result;
        }
    }

    public List<Products> GetProdWithSmallestQoantity(){
        using (var connection = context.GetConnection())
        {
            var cmd = @"
select * from products 
where quantity < (select Min(quantity) from products)";

            
            var result = connection.Query<Products>(cmd).ToList();
           return result;
        }

    }

    
}

