using Microsoft.AspNetCore.Mvc;
using university_Project.Models;

namespace university_Project.Controllers
{
    public class TestErrorMassageController : Controller
    {
        [ErrorHandeler]
        public IActionResult Index()
        {
            throw new Exception("Exception Fr index ");
        }
    }
}
