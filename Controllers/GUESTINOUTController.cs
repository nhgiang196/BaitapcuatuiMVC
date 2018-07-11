using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaitapcuatuiMVC.Controllers
{
    public class GUESTINOUTController : Controller
    {
        db_fepvnEntities1 db = new db_fepvnEntities1();
        // GET: /GUESTINOUT/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GUEST_INOUT = db.GUEST_INOUT.ToList(); //error
            DropdowlistGID();
            DropdowlistCID();
            DropdowlistRID();
            DropdowlistGSTATEID();
            return RedirectToAction("/Home/Index");
        }

        private void DropdowlistRID(string RID = null)
        {
            ViewBag.RID = new SelectList(db.GUEST_REGISTRATION.ToList(), "RID", "RID");
        }

        private void DropdowlistGSTATEID(string selectedGSTATEID = null)
        {
            ViewBag.GSTATEID = new SelectList(db.GSTATEs.ToList(), "GSTATEID", "GSTATEID");
        }



        private void DropdowlistCID(string selectedCID = null)
        {
            ViewBag.CID = new SelectList(db.CARDS.ToList(), "CID", "CID");
        }

        private void DropdowlistGID(string selectedGID = null)
        {
            ViewBag.GID = new SelectList(db.GUESTs.ToList(), "GID", "GNAME");
        }


        [HttpPost]
        public ActionResult Create(GUEST_INOUT model)
        {
            db.GUEST_INOUT.Add(model);
            db.SaveChanges();
            return View();
        }
       
	}
}