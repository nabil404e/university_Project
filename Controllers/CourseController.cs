using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using university_Project.Models;
using university_Project.Repostitray;
namespace university_Project.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class CourseController : Controller
    {

        ICouresRepostitray CoursesRepost;
        iDepartment DepartmentRepost; 

        public  CourseController(ICouresRepostitray couresRepo , iDepartment Department_Repo)
        {
            CoursesRepost = couresRepo;

            DepartmentRepost = Department_Repo; 
        }

       

        public IActionResult Index()
        {

            var  Course = CoursesRepost.Get_All()
                .Select(c => new DepartmentViewModel
                {
                    ID = c.ID,
                    Name = c.Name,
                    Degree = c.Degree,
                    Min_Degree = c.Min_Degree,
                    Department = DepartmentRepost.Find_Using_ID(c.Depart_ID)
                }).ToList();



            return View("Show_ALL_Course" ,Course);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments  =new SelectList(DepartmentRepost.Get_All(), "ID", "Name"); 
            return View("Create");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cls_Course REQ_Course)
        {
            if(ModelState.IsValid)
            {
                CoursesRepost.Add(REQ_Course);
                CoursesRepost.Save(); 
                return RedirectToAction("Index");
            }

            ViewBag.Departments  = new SelectList(DepartmentRepost.Get_All(), "ID", "Name");
            return View(REQ_Course);
        }

        [HttpGet]

        public IActionResult Edit(int  id  )
        {

            Cls_Course OBJ_Courese = CoursesRepost.Find_Using_ID(id);
            if(OBJ_Courese == null)
            {
                return NotFound(); 
            }

            ViewBag.Departments  =new SelectList(DepartmentRepost.Get_All(), "ID", "Name");
            return View("Edit", OBJ_Courese); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Cls_Course REQ_Course , int  id)
        {
            

            if(ModelState.IsValid)
            {
                Cls_Course OBJ_Courese = CoursesRepost.Find_Using_ID(id); 

                if(OBJ_Courese == null)
                {
                    return NotFound(); 
                }
                OBJ_Courese.Name = REQ_Course.Name;
                OBJ_Courese.Min_Degree = REQ_Course.Min_Degree;
                OBJ_Courese.Depart_ID = REQ_Course.Depart_ID;
                OBJ_Courese.Degree = REQ_Course.Degree;

                CoursesRepost.Edit(OBJ_Courese);
                CoursesRepost.Save(); 
                return RedirectToAction("Index");
            }

            ViewBag.Departments  =new SelectList(DepartmentRepost.Get_All(), "ID", "Name");
 
            return View(REQ_Course);

        }



        public  IActionResult Delete(  int id  )
        {    
            if(CoursesRepost.Delete(id ) == true )
            {
                CoursesRepost.Save();
                return RedirectToAction("Index");
            }

            return View(); 
            
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IS_Valid_MIn_Degree(double Min_Degree)
        {
            bool valid = Min_Degree >= 20 && Min_Degree <= 50;
            return Json(valid);
        }



        [AcceptVerbs("Get", "Post")]
        public IActionResult IS_Valid_Name(string Name, int ID)
        {
            bool exists = CoursesRepost.IS_Valid_Name(Name, ID); 
            return Json(!exists);
        }




    }
}
