namespace MvcProject.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public List<string> CategoryNames { get; set; }

        public List<string> TagName { get; set; }

    }
}
