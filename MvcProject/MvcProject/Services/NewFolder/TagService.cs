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
        }
    }

