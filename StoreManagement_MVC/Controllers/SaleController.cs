using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement_MVC.Models;

namespace StoreManagement_MVC.Controllers
{
    public class SaleController : Controller
    {
        private DbEntity db = new DbEntity();
        
        // GET: Sale
        public ActionResult SaleDetails()
        {
            return View(db.Sales.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Sale saletoAdd)
        {
            if (!ModelState.IsValid)
                return View();
            db.Sales.Add(saletoAdd);
            db.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("SaleDetails");


        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            var saleEdit = (from m in db.Sales where m.id==id select m).First();
            return View(saleEdit);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(Sale saleID)
        {
            var orignalRecord = (from m in db.Sales where m.id == saleID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            db.Entry(orignalRecord).CurrentValues.SetValues(saleID);

            db.SaveChanges();
            return RedirectToAction("SaleDetails");


        }

        // GET: Sale/Delete/5
        public ActionResult Delete(Sale saleID)
        {
            var d = db.Sales.Where(x => x.id==saleID.id).FirstOrDefault();
            db.Sales.Remove(d);
            db.SaveChanges();
            return RedirectToAction("SaleDetails");
        }

        // POST: Sale/Delete/5
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
