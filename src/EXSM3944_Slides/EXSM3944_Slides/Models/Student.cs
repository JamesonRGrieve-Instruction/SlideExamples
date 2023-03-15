using System.ComponentModel.DataAnnotations;

namespace EXSM3944_Slides.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters long.")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters long.")]
        public string? LastName { get; set; }

        public DateOnly BirthDate { get; set; }
    }
}

