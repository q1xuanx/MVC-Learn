using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
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
        [Range(0, 100,ErrorMessage ="Display order must be between 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
