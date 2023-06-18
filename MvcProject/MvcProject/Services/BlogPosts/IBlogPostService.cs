using MvcProject.Models;

namespace MvcProject.Services.BlogPosts
{
    public interface IBlogPostService
    {
        BlogPostModel FindById(int id);
        List<BlogPostModel> FindAllPosts();
        int Create(BlogPostModel model, string userId);

        List<BlogPostModel> FindAllPostsByUserId(BlogPostModel model, string userId);
        void Update(BlogPostModel model);

        BlogPostModel FindByUserId(string id);

        void Delete(int id);
    }
}
