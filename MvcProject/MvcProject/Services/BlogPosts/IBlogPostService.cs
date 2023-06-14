using MvcProject.Models;

namespace MvcProject.Services.BlogPosts
{
    public interface IBlogPostService
    {
        BlogPostModel FindById(int id);
        List<BlogPostModel> FindAllPosts();
        int Create(BlogPostModel model, string userId);
    }
}
