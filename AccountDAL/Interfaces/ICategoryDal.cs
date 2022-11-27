using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICategoryDal
    {
        List<CategoryDTO> GetAllСategories();
        CategoryDTO CreateCategory(CategoryDTO category);
        CategoryDTO UpdateCategory(CategoryDTO newCategory, int id);
        CategoryDTO DeleteCategory(int id);
    }
}
