using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2, ErrorMessage = "Message must be at least 2 characters in length.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Favorite is required!")]
        public string Favorite { get; set; }

        [Required(ErrorMessage = "Comment is required!")]
        [MinLength(20, ErrorMessage = "Message must be at least 20 characters in length.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Register date time is required!")]
        [FutureDateAttribute]
        public DateTime? RegisterDateTime { get; set; }

        public Survey() { }

        public Survey(string name, string location, string favorite, string comment)
        {
            Name = name;
            Location = location;
            Favorite = favorite;
            Comment = comment;
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            DateTime inputDate = (DateTime)value;
            DateTime dateTimeNow = DateTime.Now;
            
            if (inputDate > dateTimeNow)
            {
                return new ValidationResult("The date must be a future date.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
