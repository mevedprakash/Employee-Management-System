using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Entity;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IRepository<Employee> empRepo;
        private readonly IRepository<Department> depRepo;

        public DashboardController(IRepository<Employee> empRepo,IRepository<Department> depRepo)
        {
            this.empRepo = empRepo;
            this.depRepo = depRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> TotalSalary()
        { 
            var empList = await empRepo.GetAll();
            var totalSalary = empList.Sum(x => x.Salary ?? 0);
            var employeeCount = empList.Count;
            var depList = await depRepo.GetAll();
            var departmentCount = depList.Count;
            return Ok(new
            {
                TotalSalary = totalSalary,
                employeeCount = employeeCount,
                departmentCount = departmentCount
            });
        }
        [HttpGet("department-data")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDepartmentData()
        {
            var depList = await depRepo.GetAll();
            var empList = await empRepo.GetAll();
            var result = empList.GroupBy(x => x.DepartmentId).Select(y => new DepartmentDataDto()
            {
                Name = depList.FirstOrDefault(z => z.Id == y.Key)?.Name!,
                EmployeeCount = y.Count(),
            });
            return Ok(result);
        }

    }
}
