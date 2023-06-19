using MvcProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class BlogCategoryViewModel : BlogPostModel
    {
        public List<CategoryModel> AllCategories { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; }
    
    }
}
