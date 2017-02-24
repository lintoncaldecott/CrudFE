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
        [DisplayName("User Name (email)")]
        public string UserName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
    }
}