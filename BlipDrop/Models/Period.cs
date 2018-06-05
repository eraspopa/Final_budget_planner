using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlipDrop.Models
{
    public class Period
    {
        [Key]
        [MaxLength(3)]
        public string PeriodId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PeriodNameEnglish { get; set; }
    }
}