using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using university_Project.Models;
using university_Project.Repostitray;

namespace university_Project.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class DepartmentController : Controller
    {

        iDepartment departmentReposrt; 
        public  DepartmentController(iDepartment departmentRepo)
        {
            departmentReposrt = departmentRepo;
        }


        public IActionResult Index()
        {
            List<Cls_Department> departments = new List<Cls_Department>();
            departments =departmentReposrt.Get_All(); 
            
            return View("Department_List" , departments);
        }
    }
}
