using MvcProject.Data;
using MvcProject.Models;
using MvcProject.Services.Category;

namespace MvcProject.Services.NewFolder
{
    public class TagService : ITagService
    { 
            private readonly ApplicationDbContext _context;
            public TagService(ApplicationDbContext context)
            {
                _context = context;
            }

            public int Create(TagModel model)
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    throw new Exception("ne moje da e prazno");
                }

                var tag = new Data.Entities.Tag()
                {
                    TagName = model.Name
                };

                this._context.Tags.Add(tag);
                this._context.SaveChanges();

                return tag.TagId;
            }

            public List<TagModel> GetAllTag()
            {
                return this._context.Tags.Select(x => new TagModel
                {
                    Name = x.TagName,
                    Id = x.TagId
                }).ToList();
            }
        public void Update(TagModel model)
        {
            var post = this._context.Tags.FirstOrDefault(x => x.TagId == model.Id);

            if (post == null)
            {
                throw new Exception("Post Not Found");
            }

            post.TagName = model.Name;


            this._context.SaveChanges();
        }

        public TagModel GetTagById(int id)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.TagId == id);


            var model = new TagModel
            {
                Id = tag.TagId,
                Name = tag.TagName
            };

            return model;
        }

        public void Delete(int id)
        {
            var post = _context.Tags.FirstOrDefault(x => x.TagId == id);


            _context.Tags.Remove(post);
            _context.SaveChanges();

        }
    }
    }

