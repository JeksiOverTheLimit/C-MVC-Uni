using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Entities
{
    public class BlogPostTags
    {
        [Key]
        public int Id { get; set; }

        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
