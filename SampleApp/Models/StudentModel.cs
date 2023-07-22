using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleApp.Models
{

    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("First name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        [Required(ErrorMessage ="Last name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        [Required(ErrorMessage = "Email can't be empty")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Department field is required")]
        public string Department { get; set; }

        [EmailAddress(ErrorMessage ="Username must be in email format")]
        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; }
        

    }
    public static class PasswordHelper
    {
        public static string HidePassword(string actualPassword)
        {
            if (string.IsNullOrEmpty(actualPassword))
                return string.Empty;
            return new string('•', actualPassword.Length);
        }
    }

}