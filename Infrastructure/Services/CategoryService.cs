using Dapper;
using Domain.Entities;
using Domain.Entities.DTOs;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly DataContext context = new DataContext();
    public void AddCategory(Category category)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            insert into category(Name) 
            values(@Name);";
            var result = connection.Execute(cmd,category);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public void DeleteCategory(int id)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            delete from category 
            where id = @id";
            var result = connection.Execute(cmd, new {id = id} );
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public List<Category> GetAllCategories()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"select * from category";
            List<Category> result = connection.Query<Category>(cmd).ToList();
            
            return result;
        }
    }


    public void UpdateCategory(Category category)
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
            update category
            set Name = @Name
            where id = @Id";
            int result = connection.Execute(cmd,category);
            System.Console.WriteLine(result>0 ? "Sucsses" : "Failed");
        }
    }

    public List<CategoryDTO> GetCategoryWithCount()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
select c.name, count(p.id) from products p
join category c on c.id = p.categoryId
group by c.name";
            List<CategoryDTO> result = connection.Query<CategoryDTO>(cmd).ToList();
            
            return result;
        }
    }

    public void AddDateTimeToCategory()
    {
        using (var connection = context.GetConnection())
        {
            var cmd = @"
alter table category 
add column DataCreated default Current_date;";
            
            var result = connection.Execute(cmd);
            
            System.Console.WriteLine(result==0 ? "Sucssesfuly added column date" : "Failed");
            
        }
    }

}
