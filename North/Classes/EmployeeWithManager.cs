using System;

namespace North.Classes
{
    public class EmployeeWithManager
    {
        public int Id { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
    }
}