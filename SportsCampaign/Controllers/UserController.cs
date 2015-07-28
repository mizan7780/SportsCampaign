using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsCampaign.Controllers
{
    public class UserController : Controller
    {
        Models.SportsCampaignDBEntities de = new Models.SportsCampaignDBEntities();
        //
        // GET: /User/

        public ActionResult Index()
        {
            var result = from u in de.UserTables
                         select u;
            return View(result.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            var result = from u in de.UserTables
                         where u.id == id
                         select u;
            Models.UserTable ut = new Models.UserTable();
            foreach(var r in result)
            {
                ut = r;
            }
            return View(ut);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {

            var result = from u in de.UserTables
                         where u.id == id
                         select u;
            Models.UserTable ut = new Models.UserTable();
            foreach (var r in result)
            {
                ut = r;
            }
            return View(ut);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Models.UserTable ut)
        {
            try
            {
                var result = from u in de.UserTables
                             where u.id == id
                             select u;
                foreach (var r in result)
                {
                     r.userName=ut.userName;
                     r.userPassword=ut.userPassword ;
                     r.userType=ut.userType;
                     de.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            var result = from u in de.UserTables
                         where u.id == id
                         select u;
            Models.UserTable ut = new Models.UserTable();
            foreach (var r in result)
            {
                ut = r;
            }
            return View(ut);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Models.UserTable ut)
        {
            try
            {
                var result = from u in de.UserTables
                             where u.id == id
                             select u;
                foreach (var r in result)
                {
                    de.UserTables.Remove(r);
                }
                de.SaveChanges();
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
