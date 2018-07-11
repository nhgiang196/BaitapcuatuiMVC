using BaitapcuatuiMVC.Models;
using Model.Dao;
using BaitapcuatuiMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BaitapcuatuiMVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)//kiem tra forrm rong
            {
                var dao = new EMPLOYEES_Dao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var ten_TK = dao.GetByten_tk(model.UserName);//ten_TK tu input them vao neu trung voi csdl thi gan vao user

                    var userSession = new UserLogin();
                    userSession.ten_tk = userSession.ten_tk;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại kìa cha nọi");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sai mật khẩu gòi kìa .");
                    }

                }
            }
            return View("Index");
        }

        //Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();//huy nhung cai cookie, nhung session mà nó tạo haizzzzzzzz
            return RedirectToAction("Index", "Login");
        }
	}
}