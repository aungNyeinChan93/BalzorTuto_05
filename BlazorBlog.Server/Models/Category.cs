using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Server.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public required string Name { get; set; }
        

    }
}
