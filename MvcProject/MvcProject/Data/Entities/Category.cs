using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
    }
}
