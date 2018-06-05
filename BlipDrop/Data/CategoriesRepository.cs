using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class CategoriesRepository
    {
        public IEnumerable<SelectListItem> GetCategories()
        {
            List<SelectListItem> Categories = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return Categories;
        }

        public IEnumerable<SelectListItem> GetCategories(string SubcategoryId)
        {
            if (!String.IsNullOrWhiteSpace(SubcategoryId))
            {
                using (var context = new ApplicationDbContext())
                {
                    IEnumerable<SelectListItem> Categories = context.Categories.AsNoTracking()
                        .OrderBy(n => n.CategoryNameEnglish)
                        .Where(n => n.SubcategoryId == SubcategoryId)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.CategoryCode,
                               Text = n.CategoryNameEnglish
                           }).ToList();
                    return new SelectList(Categories, "Value", "Text");
                }
            }
            return null;
        }
    }
}