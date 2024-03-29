﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppHotelManagement.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name = "Room No.")]
        [Required(ErrorMessage ="Room number is required.")]

        public string RoomNumber { get; set; }
        [Display(Name = "Room Image")]

        public string RoomImage { get; set; }
        

        [Display(Name = "Room Price")]
        [Required(ErrorMessage = "Room price is required.")]
        [Range(1, 100000, ErrorMessage = "Room price should be greater than {1} and smaller than {2}")]
        public decimal RoomPrice { get; set; }

        [Display(Name = "Booking Status")]
        [Required(ErrorMessage = "Booking status is required.")]

        public int BookingStatusId { get; set; }

        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Room type is required.")]

        public int RoomTypeId { get; set; }

        [Display(Name = "Room Capacity")]
        [Required(ErrorMessage = "Room capacity is required.")]
        [Range (1,20, ErrorMessage = "Room capacity should be equal or greater than {1}")]

        public int RoomCapacity { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Room Description")]
        [Required(ErrorMessage = "Room description is required.")]

        public string RoomDescription { get; set; }
        

        public List<SelectListItem> ListofBookingStatus { get; set; }

        public List<SelectListItem> ListofRoomType { get; set; }

    }
}
