using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHotelManagement.Models;


namespace WebAppHotelManagement.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            Users userModel = new Users();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Users userModel)
        {
            using(HotelDBEntities dbModel=new HotelDBEntities())
            {
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration is succesful.";
            return View("AddOrEdit", new Users());
        }
    }
}