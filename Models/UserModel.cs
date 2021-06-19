using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueberryPro.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Full Name is Missing")]
        [MinLength(10, ErrorMessage ="provide Minimum 10 character name")]
        public string FullName { get; set; }

        [RegularExpression("@",ErrorMessage ="Please provide your vallid Email Address")]
        public string Email { get; set; }
        public String Password { get; set; }
        public string Gender{ get; set; }
    }
}
