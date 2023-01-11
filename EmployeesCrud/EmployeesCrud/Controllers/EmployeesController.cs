using Microsoft.AspNetCore.Mvc;

namespace EmployeesCrud.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
