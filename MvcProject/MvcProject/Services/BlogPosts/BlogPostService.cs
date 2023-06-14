using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcProject.Data;
using MvcProject.Data.Entities;
using MvcProject.Models;
using System.Reflection;

namespace MvcProject.Services.BlogPosts
{
    public class BlogPostService : IBlogPostService
    {
        private readonly ApplicationDbContext _context;

        public BlogPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(BlogPostModel model, string userId)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new Exception("ne moje da e prazno");
            }

            var post = new BlogPost()
            {
                Title = model.Title,
                Description = model.Description,
                UserId = userId
            };

            this._context.Posts.Add(post);
            this._context.SaveChanges();

            return post.BlogId;
        }
        public List<BlogPostModel> FindAllPosts()
        {
            var allPosts = this._context.Posts.Select(x => new BlogPostModel{
                Id = x.BlogId,
                Title = x.Title,
                Description = x.Description,
                AuthorName = x.User.UserName

            }).ToList();
            return allPosts;
        }

        public BlogPostModel FindById(int id)
        {
            var blogPost = this._context.Posts
                .Where(x => x.BlogId == id)
                .Select(x => new BlogPostModel
                {
                    Id = x.BlogId,
                    Title = x.Title,
                    Description = x.Description,
                    AuthorName = x.User.UserName
                })
                .FirstOrDefault();

            if (blogPost == null)
            {
                throw new Exception("Post Not Found");
            }

            return blogPost;
        }

    }
}
