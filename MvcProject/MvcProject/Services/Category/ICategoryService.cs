using MvcProject.Models;

namespace MvcProject.Services.Category
{
    public interface ICategoryService
    {
        int Create(CategoryModel model);
        List<CategoryModel> GetAllCategory();

        void Update(CategoryModel model);

        CategoryModel GetCategoryById(int id);
        void Delete(int id);
    }
}
