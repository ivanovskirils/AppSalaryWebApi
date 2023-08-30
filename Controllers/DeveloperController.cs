using Microsoft.AspNetCore.Mvc;

namespace SalaryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeveloperController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("high-salary-devs")]
        public ActionResult<IEnumerable<object>> GetHighSalaryDevelopers()
        {
            var highSalaryDevelopers = _context.Developers
                .Where(dev => dev.Salary > dev.Manager.Salary)
                .Select(dev => new
                {
                    DeveloperName = $"{dev.FirstName} {dev.LastName}",
                    DeveloperSalary = dev.Salary,
                    ManagerName = $"{dev.Manager.FirstName} {dev.Manager.LastName}",
                    ManagerSalary = dev.Manager.Salary,
                    Department = new
                    {
                        dev.Department.Id,
                        dev.Department.Name
                    }
                })
                .ToList();

            return Ok(highSalaryDevelopers);
        }
    }

}
