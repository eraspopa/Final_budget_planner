using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BlipDrop.Data;
using BlipDrop.ViewModels;

namespace BlipDrop.Controllers
{
    public class RecordsController : Controller
    {
        // GET: Record
        public ActionResult Index()
        {
            var repo = new RecordsRepository();
            var RecordList = repo.GetRecords();
            return View(RecordList);
        }

        [HttpGet]
        public ActionResult GetCategories(string SubcategoryId)
        {
            if (!string.IsNullOrWhiteSpace(SubcategoryId))
            {
                var repo = new CategoriesRepository();

                IEnumerable<SelectListItem> Categories = repo.GetCategories(SubcategoryId);
                return Json(Categories, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        // GET: Record/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Record/Create
        public ActionResult Create()
        {
            var repo = new RecordsRepository();
            var Record = repo.CreateRecord();
            return View(Record);
        }

        // POST: Record/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "RecordId, RecordName, SelectedSubCategoryId, SelectedCategoryCode, SelectedPeriodId ")] RecordEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new RecordsRepository();
                    bool saved = repo.SaveRecord(model);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }
                // Handling model state errors is beyond the scope of the demo, so just throwing an ApplicationException when the ModelState is invalid
                // and rethrowing it in the catch block.
                throw new ApplicationException("Invalid model");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        // GET: Record/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Record/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Record/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Record/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
