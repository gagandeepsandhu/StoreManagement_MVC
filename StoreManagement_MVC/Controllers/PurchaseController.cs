using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using StoreManagement_MVC.Models;
namespace StoreManagement_MVC.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        private DbEntity db = new DbEntity();

        public ActionResult PurchaseDetails()
        {
            return View(db.Purchases.ToList());
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Purchase PurchaseAdd)
        {
            if(!ModelState.IsValid)
                return View();
            db.Purchases.Add(PurchaseAdd);
             db.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("PurchaseDetails");
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            var purhcaseEdit = (from m in db.Purchases where m.id == id select m).First();
            return View(purhcaseEdit);
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(Purchase PurchaseID)
        {

            var orignalRecord = (from m in db.Purchases where m.id == PurchaseID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            db.Entry(orignalRecord).CurrentValues.SetValues(PurchaseID);

            db.SaveChanges();
            return RedirectToAction("PurchaseDetails");

        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(Purchase PurchaseID)
        {
            var d = db.Purchases.Where(x => x.id== PurchaseID.id).FirstOrDefault();
            db.Purchases.Remove(d);
            db.SaveChanges();
            return RedirectToAction("PurchaseDetails");
            


        }

        // POST: Purchase/Delete/5
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
