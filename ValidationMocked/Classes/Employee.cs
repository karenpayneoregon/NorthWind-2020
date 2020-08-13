using System;
using System.ComponentModel.DataAnnotations;

namespace ValidationMocked.Classes
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        public DateTime? HireDate { get; set; }
        [Required(ErrorMessage = "Please enter your {0} email address")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(70)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", 
            ErrorMessage = "Please enter correct {0} email")]
        public string PersonalEmail { get; set; }
    }
}
