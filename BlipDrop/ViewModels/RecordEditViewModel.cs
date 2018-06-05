using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlipDrop.ViewModels
{
    public class RecordEditViewModel
    {
        public string RecordId { get; set; }

        [Required]
        [Display(Name = "Subcategory")]
        public string SelectedSubCategoryId { get; set; }

        public IEnumerable<SelectListItem> Subcategories { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string SelectedCategoryCode { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal AmountValue { get; set; }

        [Required]
        [Display(Name = "Period")]
        public string SelectedPeriodId { get; set; }
        public IEnumerable<SelectListItem> periods { get; set; }
    }
}