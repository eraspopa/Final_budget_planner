using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class SubcategoriesRepository
    {
        public IEnumerable<SelectListItem> GetSubcategories()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> Subcategories = context.Subcategories.AsNoTracking()
                    .OrderBy(n => n.SubcategoryNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.SubcategoryId.ToString(),
                            Text = n.SubcategoryNameEnglish
                        }).ToList();
                var Subcategorytip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select Subcategory ---"
                };
                Subcategories.Insert(0, Subcategorytip);
                return new SelectList(Subcategories, "Value", "Text");
            }
        }
    }
}