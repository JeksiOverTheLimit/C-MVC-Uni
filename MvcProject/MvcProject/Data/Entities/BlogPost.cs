using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Entities
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comments>();
        }

        [Key]
        public int BlogId { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
