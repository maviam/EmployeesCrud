using EmployeesCrud.Data;
using EmployeesCrud.Models;
using EmployeesCrud.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _dataContext;

        public EmployeesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department,
            };
            
            // Put the data in the form inside the DbSet Employees
            await _dataContext.Employees.AddAsync(employee);
            // Save changes in the database
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Add));
        }
    }
}
