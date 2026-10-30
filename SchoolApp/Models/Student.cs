using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApp.Validation;

namespace SchoolApp.Models
{
    public class Student
    {
        // The primary key. The database numbers each student by itself.
        public int StudentId { get; set; }

        // Student number validation
        [Display(Name = "Student No.")]
        [Required(ErrorMessage = "Please enter the student number.")]
        // ^ start, \d{4} four digits, - a dash, \d{4} four digits, $ end
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Use the format 2026-0001.")]
        public string? StudentNo { get; set; }

        // Name validation
        [Display(Name = "Full Name")] //LOL KALA KO PAPALITAN DIN UNG FULL NAME HAHAHHAHA
        [Required(ErrorMessage = "Please enter the student's name. - Alex")]
        [StringLength(100, ErrorMessage = "The name can't be longer than 100 characters.")]
        public string? Name { get; set; }

        // Email validation
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email, like ana@example.com.")]
        public string? Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Required(ErrorMessage = "Please type the email again.")]
        // [NotMapped]: form only, not saved as a column
        [NotMapped]
        // [Compare("Email")]: must be exactly the same as Email
        [Compare("Email", ErrorMessage = "Emails do not match.")]
        public string? ConfirmEmail { get; set; }

        // Phone validation
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string? Phone { get; set; }

        // Age validation
        [Range(16, 60, ErrorMessage = "Age must be from 16 to 60.")]
        public int? Age { get; set; }

        [Display(Name = "Birth Date")]
        // Shows a date picker without the time
        [DataType(DataType.Date)]
        // Our custom rule from Validation/NotFutureDateAttribute.cs
        [NotFutureDate(ErrorMessage = "Birth date can't be in the future.")]
        public DateTime? BirthDate { get; set; }
    }
}