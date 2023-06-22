using MvcProject.Models;

namespace MvcProject.Services.NewFolder
{
    public interface ITagService
    {
        int Create(TagModel model);
        List<TagModel> GetAllTag();

        void Delete(int id);
        TagModel GetTagById(int id);

        void Update(TagModel model);
    }
}
