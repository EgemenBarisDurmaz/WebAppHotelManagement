using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHotelManagement.Models;
using System.Web.Security;

namespace WebAppHotelManagement.Controllers
{
    public class SecurityController : Controller
    {
        HotelDBEntities db = new HotelDBEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            var userInDb = db.Users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if(userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(user.userName, false);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Mesaj = "Unvalid user. Username or password is wrong.";
                    return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
    
    }
