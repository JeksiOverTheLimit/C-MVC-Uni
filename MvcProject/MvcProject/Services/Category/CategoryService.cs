using MvcProject.Data;
using MvcProject.Data.Entities;
using MvcProject.Models;


namespace MvcProject.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(CategoryModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new Exception("ne moje da e prazno");
            }

            var category = new Data.Entities.Category()
            {
                CategoryName = model.Name
            };

            this._context.Categories.Add(category);
            this._context.SaveChanges();

            return category.CategoryId;
        }

        public List<CategoryModel> GetAllCategory()
        {
            return this._context.Categories.Select(x => new CategoryModel
            {
                Name = x.CategoryName,
                Id = x.CategoryId
            }).ToList();
        }  
    }
}
