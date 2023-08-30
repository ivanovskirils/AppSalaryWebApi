namespace SalaryApp.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public int ManagerId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Manager Manager { get; set; }
    }
}
