using EmployeesCrud.Data;
using EmployeesCrud.Models;
using EmployeesCrud.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        public async Task<IActionResult> Index()
        {
            var employees = await _dataContext.Employees.ToListAsync();
            return View(employees);
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
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] 
        public async Task<IActionResult> Edit(Guid id) 
        {
            var employee = await _dataContext.Employees.Where(e => e.Id == id).SingleOrDefaultAsync();
            return View(employee);
        }
    }
}
