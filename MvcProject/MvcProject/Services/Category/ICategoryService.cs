using MvcProject.Models;

namespace MvcProject.Services.Category
{
    public interface ICategoryService
    {
        int Create(CategoryModel model);
        List<CategoryModel> GetAllCategory();
    }
}
