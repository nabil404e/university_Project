using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using university_Project.Models;
using university_Project.Repostitray;
using university_Project.ViewModel;

namespace university_Project.Controllers
{
   
    public class ApplyCourseController : Controller
    {

        iApplayForm iApplayFormRepost;


        ICouresRepostitray CoursesRepost;
        iDepartment DepartmentRepost;
        public ApplyCourseController(iApplayForm ApplayFormRepo, iDepartment iDepartmentRepost ,ICouresRepostitray couresRepostitray)
        {   
            iApplayFormRepost = ApplayFormRepo;
            this.DepartmentRepost=iDepartmentRepost;
            this.CoursesRepost = couresRepostitray;
        }




        public IActionResult index()
        {
            return View();
        }
        public IActionResult ShowAll()
        {
            var FormData = iApplayFormRepost.ShowAll()
                .Select(a => new ApplayCourseViewModel
                {
                    ID = a.ID,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Address = a.Address,
                    Email = a.Email,
                    Phone = a.Phone,
                    Gender = a.Gender,
                    RegistrationDate = a.RegistrationDate,
                    course = a.Course ,
                    Department = a.Department 
                }).ToList();

            return View("ShowAll", FormData);
        }



        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.Departments  = new SelectList(DepartmentRepost.Get_All(), "ID", "Name");
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(AppApplayCourse applayCourse)
        {

            if (ModelState.IsValid)
            {
                iApplayFormRepost.Add(applayCourse);

                iApplayFormRepost.Save();

                return RedirectToAction("Index");


            }
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name");

            ViewBag.Departments  = new SelectList(DepartmentRepost.Get_All(), "ID", "Name");
            return View();

        }

        [HttpGet]

        public  ActionResult Edit(  int id)
        {
            AppApplayCourse applayCourse = iApplayFormRepost.Find_UsingID(id);  

            if (applayCourse == null)
            {
                return NotFound();  
            }


            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name");

            ViewBag.Departments  = new SelectList(DepartmentRepost.Get_All(), "ID", "Name");

            return View(applayCourse); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken] 

        public  IActionResult Edit  (int id, AppApplayCourse appApplay_Request)
        {

            if(ModelState.IsValid)
            {

                iApplayFormRepost.Update(appApplay_Request);
                iApplayFormRepost.Save(); 
                return RedirectToAction("ShowAll" , appApplay_Request);

            }


            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name");

            ViewBag.Departments  = new SelectList(DepartmentRepost.Get_All(), "ID", "Name");

            return View(appApplay_Request);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            if(iApplayFormRepost.Delete(id)  == true)
            {
                iApplayFormRepost.Save();
                return RedirectToAction("ShowAll"); 
            }

            return View(); 
        }
    }
}
