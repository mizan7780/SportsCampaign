using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsCampaign.Controllers
{
    public class CampaignBookedController : Controller
    {
        Models.SportsCampaignDBEntities de = new Models.SportsCampaignDBEntities();
        //
        // GET: /CampaignBooked/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CampaignBooked/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CampaignBooked/Create

        public ActionResult Create()
        {
            if (Session["username"].ToString() !="")
            {
                Models.CampaignBookedInfo cb = new Models.CampaignBookedInfo();
                var result = from c in de.CampaignTables
                             select c;
                List<SelectListItem> ListItem = new List<SelectListItem>();
                foreach (var r in result)
                {
                    ListItem.Add(new SelectListItem { Text = r.campaignName, Value = r.id.ToString() });
                }
                ViewBag.campaign = ListItem;

                //Models.RegisterTable rt = new Models.RegisterTable();
                //var register = from reg in de.RegisterTables
                //             select reg;
                //List<SelectListItem> regList = new List<SelectListItem>();
                //foreach(var r in register)
                //{
                //    regList.Add(new SelectListItem {Text=r.firstName,Value=r.id.ToString() });
                //}
                //ViewBag.registerName = regList;

                Models.catagoryTable cat = new Models.catagoryTable();
                var catagory = from c in de.catagoryTables
                               select c;
                List<SelectListItem> catagoryList = new List<SelectListItem>();
                foreach (var c in catagory)
                {
                    catagoryList.Add(new SelectListItem { Text = c.catagoryName, Value = c.id.ToString() });
                }
                ViewBag.catagory = catagoryList;
                return View();
            }
            else
            {
                return RedirectToAction("Login","Sports");
            }
                      
        }

        //
        // POST: /CampaignBooked/Create

        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            
            Models.CampaignBookedInfo cb = new Models.CampaignBookedInfo();
            var result = from c in de.CampaignTables
                         select c;
            List<SelectListItem> ListItem = new List<SelectListItem>();
            foreach (var r in result)
            {
                ListItem.Add(new SelectListItem { Text = r.campaignName, Value = r.id.ToString() });
            }
            ViewBag.campaign = ListItem;

            //Models.RegisterTable rt = new Models.RegisterTable();
            //var register = from reg in de.RegisterTables
            //             select reg;
            //List<SelectListItem> regList = new List<SelectListItem>();
            //foreach(var r in register)
            //{
            //    regList.Add(new SelectListItem {Text=r.firstName,Value=r.id.ToString() });
            //}
            //ViewBag.registerName = regList;

            Models.catagoryTable cat = new Models.catagoryTable();
            var catagory = from c in de.catagoryTables
                           select c;
            List<SelectListItem> catagoryList = new List<SelectListItem>();
            foreach (var c in catagory)
            {
                catagoryList.Add(new SelectListItem { Text = c.catagoryName, Value = c.id.ToString() });
            }
            ViewBag.catagory = catagoryList;
            try
            {
                Models.CampaignBookedInfo cbi = new Models.CampaignBookedInfo();
                cbi.PlayerName = frm[1].ToString();
                cbi.PlayerAge = frm[2].ToString();
                cbi.campaignID = Convert.ToInt32(frm[3]);
                cbi.ContactNumber = frm[4].ToString();
                cbi.catagoryID = Convert.ToInt32(frm[5]);
                cbi.MedicalCondition = frm[6].ToString();
                de.CampaignBookedInfoes.Add(cbi);
                de.SaveChanges();

                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CampaignBooked/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CampaignBooked/Edit/5

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
        // GET: /CampaignBooked/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CampaignBooked/Delete/5

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
