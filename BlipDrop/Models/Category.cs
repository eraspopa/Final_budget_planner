using System.ComponentModel.DataAnnotations;

namespace BlipDrop.Models
{
    public class Category
    {
        [Key]
        [MaxLength(3)]
        public string CategoryCode { get; set; }

        [Required]
        [MaxLength(3)]
        public string SubcategoryId { get; set; }

        [Required]
        public string CategoryNameEnglish { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}