using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsCampaign.Controllers
{
    public class ContractController : Controller
    {
        Models.SportsCampaignDBEntities de = new Models.SportsCampaignDBEntities();
        //
        // GET: /Contract/

        public ActionResult Index()
        {
            var result = from c in de.contactTables
                         select c;
            return View(result.ToList());
        }

        //
        // GET: /Contract/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Contract/Create

        public ActionResult Create()
        {
            Models.contactTable ct = new Models.contactTable();
            return View(ct);
        }

        //
        // POST: /Contract/Create

        [HttpPost]
        public ActionResult Create(Models.contactTable ct)
        {
            try
            {
                de.contactTables.Add(ct);
                de.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contract/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Contract/Edit/5

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

        //
        // GET: /Contract/Delete/5

        public ActionResult Delete(int id)
        {
            var result = from c in de.contactTables
                         where c.id == id
                         select c;
            Models.contactTable ct = new Models.contactTable();
            foreach(var r in result)
            {
                ct = r;
            }
            return View(ct);
        }

        //
        // POST: /Contract/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Models.contactTable ct)
        {
            try
            {
                var result = from c in de.contactTables
                             where c.id == id
                             select c;
                foreach (var r in result)
                {
                    de.contactTables.Remove(r);
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
