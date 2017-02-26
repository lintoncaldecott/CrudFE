using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CrudFE.Models
{
    public class UserModel
    {
        
        public int UserId { get; set; }
        [DisplayName("User Name (email address)")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,3}|[0-9]{1,6})(\]?)$", ErrorMessage = "Please enter a valid e-mail")]
        public string UserName { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "A first name is required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "A last name is required")]
        public string LastName { get; set; }

        [DisplayName("Contact Number")]
        [RegularExpression(@"0[0-9]{9}", ErrorMessage = "please provide a cellphone number in the format 0791111111")]
        public string ContactNumber { get; set; }
    }
}