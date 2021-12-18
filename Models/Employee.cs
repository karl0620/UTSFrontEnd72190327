namespace Blazor.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department DepartmentName { get; set; }
        public string PhotoPath { get; set; }
    }

    public enum Gender
    {
        Male,Female
    }
}