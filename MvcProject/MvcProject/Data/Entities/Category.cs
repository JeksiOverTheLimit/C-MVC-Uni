using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.BlogPostCategories = new HashSet<BlogPostCategories>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BlogPostCategories> BlogPostCategories { get; set; }
    }
}
