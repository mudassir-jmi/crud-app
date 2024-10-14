using CRUD_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUD_WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
            if(ModelState.IsValid)
            {
                WebAppEntities db = new WebAppEntities();
                db.tbl_Category.Add(category);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.issuccess = "Data Added Successfully!";

            }else {
                ViewBag.issuccess = "There was an error adding the data. Please check!";
            }

            return View();
        }

        public ActionResult ShowData()
        {
            WebAppEntities db = new WebAppEntities();
            var list = db.tbl_Category.ToList();

            return View(list);
        }

      
        public ActionResult Edit(int id)
        {
            WebAppEntities db = new WebAppEntities();
            var category = db.tbl_Category.Find(id);  
            return View(category);
        }

        [HttpPost]

        public ActionResult Edit(tbl_Category category)
        {
            WebAppEntities db = new WebAppEntities();
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowData");
        }

        public ActionResult Delete(int id)
        {
            WebAppEntities db = new WebAppEntities();

            var category = db.tbl_Category.Find(id);
            
            db.tbl_Category.Remove(category);
            db.SaveChanges();
            TempData["issuccess"] = "Record deleted successfully!";

            return RedirectToAction("ShowData");
        }

        public ActionResult Details(int id)
        {
            WebAppEntities db = new WebAppEntities();
            var category = db.tbl_Category.Find(id); // Fetch the specific record by id

            if (category == null)
            {
                return HttpNotFound(); // Return a 404 if the category doesn't exist
            }

            return View(category); // Pass the specific category record to the view
            
        }

    }
}