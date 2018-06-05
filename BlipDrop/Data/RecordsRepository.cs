using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlipDrop.Models;
using BlipDrop.ViewModels;

namespace BlipDrop.Data
{
    public class RecordsRepository
    {
        public List<RecordDisplayViewModel> GetRecords()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Record> records = new List<Record>();
               records = context.Records.AsNoTracking()
                    .Include(x => x.Subcategory)
                    .Include(x => x.Category)
                    .Include(x=>x.Amount)
                    .Include(x=>x.Period)
                    .ToList();

                if (records != null)
                {
                    List<RecordDisplayViewModel> RecordsDisplay = new List<RecordDisplayViewModel>();
                    foreach (var x in records)
                    {
                        var recordDisplay = new RecordDisplayViewModel()
                        {
                            RecordId = x.RecordId,
                            SubcategoryName = x.Subcategory.SubcategoryNameEnglish,
                            CategoryName = x.Category.CategoryNameEnglish,
                            AmountValue = x.Amount.AmountValue,
                            PeriodName = x.Period.PeriodNameEnglish
                        };
                        RecordsDisplay.Add(recordDisplay);
                    }
                    return RecordsDisplay;
                }
                return null;
            }
        }


        public RecordEditViewModel CreateRecord()
        {
            var cRepo = new SubcategoriesRepository();
            var rRepo = new CategoriesRepository();
            var pRepo = new PeriodsRepository();
            var Record = new RecordEditViewModel()
            {
                RecordId = Guid.NewGuid().ToString(),
                Subcategories = cRepo.GetSubcategories(),
                Categories = rRepo.GetCategories(),
                periods = pRepo.GetPeriods()
            };
            return Record;
        }

        public bool SaveRecord(RecordEditViewModel Recordedit)
        {
            if(Recordedit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(Recordedit.RecordId, out Guid newGuid))
                    {
                        var Record = new Record()
                        {
                            RecordId = newGuid,
                            SubCategoryId = Recordedit.SelectedSubCategoryId,
                            CategoryCode = Recordedit.SelectedCategoryCode,
                            PeriodId = Recordedit.SelectedPeriodId,
                            
                        };
                        Record.Subcategory = context.Subcategories.Find(Recordedit.SelectedSubCategoryId);
                        Record.Category = context.Categories.Find(Recordedit.SelectedCategoryCode);
                        Record.Period = context.Periods.Find(Recordedit.SelectedPeriodId);
                        context.Records.Add(Record);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            // Return false if Recordedit == null or RecordId is not a guid
            return false;
        }
    }
}