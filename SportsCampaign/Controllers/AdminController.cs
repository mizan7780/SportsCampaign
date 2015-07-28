using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsCampaign.Controllers
{
    public class AdminController : Controller
    {
        Models.SportsCampaignDBEntities de = new Models.SportsCampaignDBEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var result = from c in de.CampaignTables
                         select c;
            return View(result.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id)
        {
            var result = from c in de.CampaignTables
                         where c.id == id
                         select c;
            Models.CampaignTable ct = new Models.CampaignTable();
            foreach(var r in result)
            {
                ct = r;
            }
            return View(ct);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            Models.CampaignTable ct = new Models.CampaignTable();
            return View(ct);
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Models.CampaignTable ct)
        {
            try
            {
                de.CampaignTables.Add(ct);
                de.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id)
        {
            var result = from c in de.CampaignTables
                         where c.id == id
                         select c;
            Models.CampaignTable ct = new Models.CampaignTable();
            foreach (var r in result)
            {
                ct = r;
            }
            return View(ct);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var result = from c in de.CampaignTables
                             where c.id == id
                             select c;
                Models.CampaignTable ct = new Models.CampaignTable();
                foreach (var r in result)
                {
                    r.campaignName = ct.campaignName;
                    r.campaignDescription = ct.campaignDescription;
                    r.catagoryName = ct.catagoryName;
                    r.Duration = ct.Duration;
                    r.instructorName = ct.instructorName;
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
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id)
        {
            var result = from c in de.CampaignTables
                         where c.id == id
                         select c;
            Models.CampaignTable ct = new Models.CampaignTable();
            foreach (var r in result)
            {
                ct = r;
            }
            return View(ct);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Models.CampaignTable ct)
        {
            try
            {
                var result = from c in de.CampaignTables
                             where c.id == id
                             select c;
                foreach (var r in result)
                {
                    de.CampaignTables.Remove(r);
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
