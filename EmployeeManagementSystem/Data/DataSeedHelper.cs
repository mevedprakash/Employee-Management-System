using EmployeeManagementSystem.Entity;
using EmployeeManagementSystem.Service;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagementSystem.Data
{
    public class DataSeedHelper
    {
        private readonly AppDbContext dbContext;

        public DataSeedHelper(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertData()
        {
            if (!dbContext.Employees.Any())
            {
                dbContext.Employees.Add(
                    new Employee { Name = "Employee 1" });
                dbContext.Employees.Add(
                    new Employee { Name = "Employee 2" });
            }
            
            if (!dbContext.Users.Any())
            {
                var passwordHelper = new PasswordHelper();
                dbContext.Users.Add(new User()
                {
                    Email = "admin@test.com",
                    Password = passwordHelper.HashPassword("12345"),
                    Role = "Admin"
                });
                dbContext.Users.Add(new User()
                {
                    Email = "emp1@test.com",
                    Password = passwordHelper.HashPassword("12345"),
                    Role = "Employee"
                });
            }

            dbContext.SaveChanges();

        }
    }
}
