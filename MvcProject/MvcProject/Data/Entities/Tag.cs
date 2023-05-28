using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Data.Entities
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
    }
}
