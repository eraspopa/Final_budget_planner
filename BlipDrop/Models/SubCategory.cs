using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlipDrop.Models
{
    public class Subcategory
    {
        [Key]
        [MaxLength(3)]
        public string SubcategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SubcategoryNameEnglish { get; set; }

        public virtual IEnumerable<Category> Categories { get; set; }
    }
}