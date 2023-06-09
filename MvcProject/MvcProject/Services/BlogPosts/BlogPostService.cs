﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcProject.Data;
using MvcProject.Data.Entities;
using MvcProject.Models;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MvcProject.Services.BlogPosts
{
    public class BlogPostService : IBlogPostService
    {
        private readonly ApplicationDbContext _context;

        public BlogPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(BlogCategoryViewModel model, string userId)
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
            foreach (var id in model.CategoryIds)
            {
                var category = this._context.Categories.Find(id);
                if (category != null)
                {
                    post.BlogPostCategories.Add(new BlogPostCategories()
                    {
                        CategoryId = id
                    });
                }
            }

            foreach (var id in model.TagIds)
            {
                var tag = this._context.Tags.Find(id);
                if (tag != null)
                {
                    post.BlogPostTags.Add(new BlogPostTags()
                    {
                        TagId = id
                    });
                }
            }

            this._context.Posts.Add(post);
            this._context.SaveChanges();

            return post.BlogId;
        }

        public void Update(BlogPostModel model)
        {
            var post = this._context.Posts.FirstOrDefault(x => x.BlogId == model.Id);

            if (post == null)
            {
                throw new Exception("Post Not Found");
            }

            post.Title = model.Title;
            post.Description = model.Description;

            this._context.SaveChanges();
        }

        public List<BlogPostModel> FindAllPosts()
        {
            var allPosts = this._context.Posts.Select(x => new BlogPostModel
            {
                Id = x.BlogId,
                Title = x.Title,
                Description = x.Description,
                AuthorName = x.User.UserName,
                CategoryNames = x.BlogPostCategories.Select(z => z.Category.CategoryName).ToList(),
                TagName = x.BlogPostTags.Select(y=> y.Tag.TagName).ToList()

            }).ToList();
            return allPosts;
        }

        public List<BlogPostModel> FindAllPostsByUserId(BlogPostModel model, string userId)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                string message = "You dont have a post";
            }
            var allPosts = this._context.Posts.Where(x => x.UserId == userId).Select(x => new BlogPostModel
            {
                Id = x.BlogId,
                Title = x.Title,
                Description = x.Description,
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

        public BlogPostModel FindByUserId(string userId)
        {
            var blogPost = this._context.Posts
                .Where(x => x.UserId == userId)
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

        public void Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.BlogId == id);

            if (post == null)
            {
                throw new Exception("Post Not Found");
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

    }
}
