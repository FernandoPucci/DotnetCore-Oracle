using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}