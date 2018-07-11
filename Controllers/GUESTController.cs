using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaitapcuatuiMVC.Controllers
{
    public class GUESTController : Controller
    {
        db_fepvnEntities1 db = new db_fepvnEntities1();
        // GET: /GUEST/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GUEST = db.GUESTs.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(GUEST model)
        {
            db.GUESTs.Add(model);
            db.SaveChanges();
            return RedirectToAction("/Home/Index");
        }
	}
}