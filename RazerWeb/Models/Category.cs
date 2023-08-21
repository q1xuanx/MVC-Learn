using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RazerWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name of product")]
        [MaxLength(20)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage = "Display order must be between 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
