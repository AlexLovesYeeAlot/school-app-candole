using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Validation
{
    // Our own rule. It inherits from ValidationAttribute, like [Required] does.
    public class NotFutureDateAttribute : ValidationAttribute
    {
        // Runs on the server when the form is saved; value = what the user entered
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // A date later than today fails the rule
            if (value is DateTime date && date.Date > DateTime.Today)
            {
                return new ValidationResult(ErrorMessage ?? "The date can't be in the future.");
            }

            // Anything else passes (an empty date too)
            return ValidationResult.Success;
        }
    }
}