using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlipDrop.Models
{
    public class Record
    {
        [Key]
        [Column(Order = 1)]
        public Guid RecordId { get; set; }

        [Required]
        public string SubCategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        [Required]
        public string CategoryCode { get; set; }
        public virtual Category Category { get; set; }
        public Amount Amount { get; set; }
        [Required]
        public string PeriodId { get; set; }
        public virtual Period Period { get; set; }
    }
}