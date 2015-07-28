using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsCampaign.Controllers
{
    public class SportsController : Controller
    {
        Models.SportsCampaignDBEntities de = new Models.SportsCampaignDBEntities();
        //
        // GET: /Sports/

        public ActionResult Index()
        {
            var result = from rt in de.RegisterTables
                         select rt;
            return View(result.ToList());
        }

        //
        // GET: /Sports/Details/5

        public ActionResult Details(int id)
        {
            var result = from rt in de.RegisterTables
                         where rt.id == id
                         select rt;
            Models.RegisterTable reg = new Models.RegisterTable();
            foreach(var r in result)
            {
                reg = r;
            }
            return View(reg);
        }

        //
        // GET: /Sports/Create

        public ActionResult Create()
        {
            Models.RegisterTable reg = new Models.RegisterTable();
            return View(reg);
        }

        //
        // POST: /Sports/Create

        [HttpPost]
        public ActionResult Create(Models.RegisterTable reg)
        {
            try
            {
                de.RegisterTables.Add(reg);
                de.SaveChanges();
                ViewBag.msg = "Thanks for registration. Please save username and password for further use...";
                
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sports/Edit/5
        public JsonResult IsUserNameExists(string userName)
        {
            var register = de.RegisterTables.FirstOrDefault(r => r.userName == userName);
            if(register!=null)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult IsEmailExits(string email)
        {
            var register = de.RegisterTables.FirstOrDefault(r => r.email == email);
            if (register != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int id)
        {
            var result = from rt in de.RegisterTables
                         where rt.id == id
                         select rt;
            Models.RegisterTable reg = new Models.RegisterTable();
            foreach (var r in result)
            {
                reg = r;
            }

            return View(reg);
        }

        //
        // POST: /Sports/Edit/5

        [HttpPost]
        public ActionResult Edit(int id,Models.RegisterTable reg)
        {
            try
            {
                var result = from rt in de.RegisterTables
                             where rt.id == id
                             select rt;
                Models.RegisterTable re = new Models.RegisterTable();
                foreach (var r in result)
                {
                    r.firstName = re.firstName;
                    r.lastName = re.lastName;
                    r.email = re.email;
                    r.userName = re.userName;
                    r.userPassword = re.userPassword;
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
        // GET: /Sports/Delete/5

        public ActionResult Delete(int id)
        {
            var result = from rt in de.RegisterTables
                         where rt.id == id
                         select rt;
            Models.RegisterTable reg = new Models.RegisterTable();
            foreach (var r in result)
            {
                reg = r;
            }
            return View(reg);
        }

        //
        // POST: /Sports/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Models.RegisterTable reg)
        {
            try
            {
                var result = from rt in de.RegisterTables
                             where rt.id == id
                             select rt;
                Models.RegisterTable re = new Models.RegisterTable();
                foreach (var r in result)
                {
                    de.RegisterTables.Remove(r);
                }
                de.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            Models.UserTable ut = new Models.UserTable();
            return View(ut);
        }
        [HttpPost]
        public ActionResult Login(Models.UserTable ut)
        {
            try
            {
                var result = from u in de.UserTables
                             where u.userName == ut.userName &&
                             u.userPassword == ut.userPassword
                             select u;
                foreach (var r in result)
                {
                    if (result.Count() == 1 && r.userType == "Admin")
                    {
                        Session["username"] = r.userName;
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (result.Count() == 1 && r.userType == "user")
                    {
                        Session["username"] = r.userName;
                        return RedirectToAction("Create", "CampaignBooked");
                    }
                    else
                    {
                        ViewBag.msg = "Invalid user name or Password.";
                        return View();
                    }

                }
                return View();
                
                //return RedirectToAction("Index", "Home");
              
               
            }
            catch
            {
                return View();
            }
        }
    }
}
