using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Data.Entities
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comments>();
            this.BlogPostTags = new HashSet<BlogPostTags>();
            this.BlogPostCategories = new HashSet<BlogPostCategories>();
        }

        [Key]
        public int BlogId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<BlogPostCategories> BlogPostCategories { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public ICollection<BlogPostTags> BlogPostTags { get; set; }

        public string UserId { get; set;}

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }
}
