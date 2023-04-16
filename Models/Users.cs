

namespace WebAppHotelManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Users
    {
        public int id { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        public string userName { get; set; }
        [Required(ErrorMessage = "This field is required.")]    
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("password")]
        public string ConfirmPassword { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }
}
