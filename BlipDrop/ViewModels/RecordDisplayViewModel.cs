using System;
using System.ComponentModel.DataAnnotations;

namespace BlipDrop.ViewModels
{
    public class RecordDisplayViewModel
    {
        [Display(Name = "Id")]
        public Guid RecordId { get; set; }
     
        [Display(Name = "Subcategory")]
        public string SubcategoryName { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Amount")]
        public decimal AmountValue { get; set; }
        [Display(Name = "Time period")]
        public string PeriodName { get; set; }
    }
}