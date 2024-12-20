using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class Form 
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s,'-]+$", ErrorMessage = "Invalid name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s,'-]+$", ErrorMessage = "Invalid name.")]
        public string LastName { get; set; }
    }
}
