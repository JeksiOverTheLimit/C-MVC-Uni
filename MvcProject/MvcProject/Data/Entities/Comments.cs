using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Entities
{
    public class Comments
    {
        [Key]
        public int CommentsId { get; set; }
        public string UserId { get; set; }  
        public string Description { get; set; }
        public IdentityUser User { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
