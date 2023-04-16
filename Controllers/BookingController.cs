using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebAppHotelManagement.Models;
using WebAppHotelManagement.ViewModel;

namespace WebAppHotelManagement.Controllers
{   [Authorize]
    public class BookingController : Controller
    {
        private HotelDBEntities objHotelDbEntities;


        public BookingController()
        {
            objHotelDbEntities = new HotelDBEntities();
        }


        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();
            objBookingViewModel.ListofRooms= (from objRoom in objHotelDbEntities.Rooms
                            where objRoom.BookingStatusId == 2 
                select new SelectListItem()
                {
                    Text = objRoom.RoomNumber,
                    Value=objRoom.RoomId.ToString()
                   
                }
                ).ToList();
            objBookingViewModel.BookingFrom = DateTime.Now;
            objBookingViewModel.BookingTo = DateTime.Now.AddDays(1);

            return View(objBookingViewModel);
        }

        [HttpPost]
        public ActionResult Index(BookingViewModel objBookingViewModel)
        {
            int numberOfDays = Convert.ToInt32((objBookingViewModel.BookingTo - objBookingViewModel.BookingFrom).TotalDays);
            Rooms objRoom = objHotelDbEntities.Rooms.Single(model => model.RoomId == objBookingViewModel.AssignRoomId);
            decimal RoomPrice = objRoom.RoomPrice;
            decimal TotalAmount = RoomPrice * numberOfDays;
            //Burası RoomBooking de olabilir!!
            RoomBookings roomBooking = new RoomBookings()
            {
                BookingFrom = objBookingViewModel.BookingFrom,
                BookingTo = objBookingViewModel.BookingTo,
                AssignRoomId = objBookingViewModel.AssignRoomId,
                CustomerAddress = objBookingViewModel.CustomerAddress,
                CustomerName = objBookingViewModel.CustomerName,
                CustomerPhone = objBookingViewModel.CustomerPhone,
                NoOfMembers = objBookingViewModel.NumberOfMembers,
                TotalAmount = TotalAmount
            };
            objHotelDbEntities.RoomBookings.Add(roomBooking);
            objHotelDbEntities.SaveChanges();
            objRoom.BookingStatusId = 3;
            objHotelDbEntities.SaveChanges(); 


            return Json(data: new {message= "Booking transaction is succesfully completed.", success=true}, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public PartialViewResult GetAllBookingHistory()
        {
            List<RoomBookingViewModel> listOfBookingViewModels = new List<RoomBookingViewModel>();
            listOfBookingViewModels=(from objHotelBooking in objHotelDbEntities.RoomBookings
            join objRoom in objHotelDbEntities.Rooms on objHotelBooking.AssignRoomId equals objRoom.RoomId
                select new RoomBookingViewModel()
                {
                    CustomerName = objHotelBooking.CustomerName,
                    CustomerAddress = objHotelBooking.CustomerAddress,
                    CustomerPhone = objHotelBooking.CustomerPhone,
                    NumberOfMembers = objHotelBooking.NoOfMembers,
                    BookingId = objHotelBooking.BookingId,
                    RoomNumber = objRoom.RoomNumber
                
                }).ToList();
            return PartialView("_BookingHistoryPartial", listOfBookingViewModels);
       }
    }
}