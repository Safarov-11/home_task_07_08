using Domain.Entities;
using Domain.Entities.DTOs;

namespace Infrastructure.Interfaces;

public interface ICategoryService
{
    void AddCategory(Category category);
    List<Category> GetAllCategories();
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
    List<CategoryDTO> GetCategoryWithCount();
    void AddDateTimeToCategory();
}
