using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppHotelManagement.ViewModel
{
    public class RoomBookingViewModel
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfMembers { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string RoomNumber { get; set; }

    }
}