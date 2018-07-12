using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaitapcuatuiMVC.Controllers
{
    public class HomeController : Controller
    {
        db_fepvnEntities1 db = new db_fepvnEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.GUEST_REGISTRATION = db.GUEST_REGISTRATION.ToList();

            return View();


        }

     
        public ActionResult GetById(string id)
        {
            try
            {

            
            var data = db.GUEST_REGISTRATION.ToList().Where(x=>x.RID ==id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
                }
            catch (Exception e)
            {}

            return null;



        }

        [HttpGet]
        public ActionResult Create()
        {
            var x = new mymodel();
            
            return View(x);
        }
        [HttpPost]
        public ActionResult Create (mymodel model )
        {
            
            try
            {
               
               //model.RID = NextCT(db.GU,)            
               //db.GUEST_REGISTRATION.Add(model);
               // db.SaveChanges();
               //db.CUD_GUEST_REGISTRATION(model.)
                
                var k = db.CUD_GUEST_REGISTRATION("insert", model.EID, model.RDATE, model.AID, model.REASON, model.ETIMEIN, model.ETIMEOUT, "R3", model.NOTE).ToList();
                for (int i = 0; i < k.Count; i++)
                {
                    var rid = k[i].rid.ToString();
                    db.CUD_GUEST("insert", rid, model.GNAME, model.GENDER, model.BIRTHYEAR, model.COMPANY, model.POSITION, model.PHONE, model.EMAIL, model.IDCARD, model.LICENSEPLATE, model.PRESENTATIVE); 
                   
                }
                
               
            }
            catch(Exception ex){

            }
            
            
            
               
            
            return RedirectToAction("Create");
            //return View("");
        }

        

        public void DropdowlistEID(string selectedEID = null)
        {
            ViewBag.EID = new SelectList(db.EMPLOYEES.ToList(), "EID", "NAME");
        }

        public void DropdowlistAID(string selectedEID = null)
        {
            ViewBag.AID = new SelectList(db.AREAS.ToList(), "AID", "AREANAME");
        }
        public void DropdowlistRID(string selectedRID = null)
        {
            ViewBag.rid = new SelectList(db.GUEST_REGISTRATION.ToList(), "RID", "RID");
        }
        public void DropdowlistRSTATEID(string selectedEID = null)
        {
            ViewBag.RSTATEID = new SelectList(db.RSTATEs.ToList(), "RSTATEID", "RSTATENAME");
        }
        public string GetLastCT(string GUEST_REGISTRATION, string RID)
        {
            string sql = "SELECT TOP 1 " + RID + " FROM " + GUEST_REGISTRATION + " ORDER BY " + RID + " DESC";
            return (string)ExecuteScalar(sql);
        }

        //ma tu sinh
        public string NextCT(string lastCT, string prefixCT)
        {
            string lastID = GetLastCT("GUEST_REGISTRATION", "RID");
            string nextID = NextCT(lastCT, "CT");

            if (lastCT  =="")
            {
                return prefixCT + "0001";  // fixwidth default
            }
            int nextCT = int.Parse(lastCT.Remove(0, prefixCT.Length)) + 1;
            int lengthNumerCT = lastCT.Length - prefixCT.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerCT; i++)
            {
                if (nextCT < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerCT - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixCT + zeroNumber + nextCT.ToString();
                }
            }
            return prefixCT + nextCT;

        }
        //end ma tu sinh

        private string ExecuteScalar(string sql)
        {
            throw new NotImplementedException();
        }



        public System.Data.SqlDbType sqlDbType { get; set; }

        public string name { get; set; }

        public string providerName { get; set; }

        public string connectionString { get; set; }

        
    }
}