using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Data.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.BlogPostTags = new HashSet<BlogPostTags>();
        }

        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }

        public ICollection<BlogPostTags> BlogPostTags { get; set; }
    }
}
