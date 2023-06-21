using MvcProject.Models;

namespace MvcProject.Services.NewFolder
{
    public interface ITagService
    {
        int Create(TagModel model);
        List<TagModel> GetAllTag();
    }
}
