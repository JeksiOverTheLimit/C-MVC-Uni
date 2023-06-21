namespace MvcProject.Models
{
    public class BlogPostTagModel
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }

        public int TagId {get; set; }
    }
}
