using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Data.Entities
{
    public class BlogPostCategories
    {
        [Key]
        public int Id { get; set; }

        public int BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}