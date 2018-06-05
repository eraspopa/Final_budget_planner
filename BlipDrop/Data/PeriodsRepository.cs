using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class PeriodsRepository
    {
        public IEnumerable<SelectListItem> GetPeriods()
        {
            using (var context = new ApplicationDbContext())
            {
                var periods = context.Periods.AsNoTracking()
                    .OrderBy(n => n.PeriodNameEnglish)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.PeriodId.ToString(),
                            Text = n.PeriodNameEnglish
                        }).ToList();
                var Periodtip = new SelectListItem
                {
                    Value = null,
                    Text = "--- select Period ---"
                };
                periods.Insert(0, Periodtip);
                return new SelectList(periods, "Value", "Text");
            }
        }
    }
}