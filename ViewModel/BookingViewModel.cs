using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace WebAppHotelManagement.ViewModel
{
    public class BookingViewModel
    {
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "Customer address is required.")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Customer Phone")]
        [Required(ErrorMessage = "Customer phone is required.")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Booking From")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Booking from is required.")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime BookingFrom { get; set; }
        [Display(Name = "Booking To")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Booking to is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingTo { get; set; }
        [Display(Name = "Assign Room")]
        [Required(ErrorMessage = "Room assignment is required.")]
        public int AssignRoomId { get; set; }
        [Display(Name = "Number of Members")]
        [Required(ErrorMessage = "Number of members is required.")]
        public int NumberOfMembers { get; set; }
        public IEnumerable<SelectListItem> ListofRooms { get; set;}


    }
}