using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using university_Project.Models;
using university_Project.Repostitray;

namespace university_Project.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class InstructorsController : Controller
    {
        Instractor  instractorRepost;

        iDepartment departmentRepost;

        ICouresRepostitray CoursesRepost; 

        public InstructorsController(Instractor instractorrepo , iDepartment departmentrepo , ICouresRepostitray couresRepo)
        {
            instractorRepost = instractorrepo;
            departmentRepost = departmentrepo;
            CoursesRepost= couresRepo;  

        }
        public IActionResult Index()
        {
            var instructors = instractorRepost.Get_All()
                .Select(i => new InstructorViewModel
                {
                    ID = i.ID,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary,
                    DepartmentName = departmentRepost.Find_Using_ID(i.Depart_ID)?.Name,
                    CourseName = CoursesRepost.Find_Using_ID(i.CRS_ID)?.Name
                }).ToList();

            return View("Instrutors_List", instructors);
        }


        public IActionResult Find_Using_ID(int ID)
        {
            var model = instractorRepost.Find_Using_ID(ID); 

            if (model == null)
            {
                return NotFound($"Instructor with ID {ID} not found.");
            }

            return View("Find_Using_ID", model); // Looks for Views/Instructor/Find_Using_ID.cshtml
        }


        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name");
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name");
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cls_Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                instractorRepost.Add(instructor);
                instractorRepost.Save();  
                return RedirectToAction("Index");
            }

            // Refill dropdowns if ModelState fails
            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name", instructor.Depart_ID);
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name", instructor.CRS_ID);

            return View(instructor);
        }

        public  IActionResult Edit( int  iD  )
        {

            Cls_Instructor instrutor_Obj = instractorRepost.Find_Using_ID(iD);
            if (instrutor_Obj == null)
            {
                return NotFound(); 
            }
            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name", instrutor_Obj.Depart_ID);
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name", instrutor_Obj.CRS_ID);

            return View("Edit" ,instrutor_Obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Cls_Instructor instrutor_Req , int  iD)
        {

            
            if (ModelState.IsValid)
            {

                Cls_Instructor Current_Instractor = instractorRepost.Find_Using_ID(iD);   // find  user  data 
                if (Current_Instractor == null)   // check nullable 
                {
                    return NotFound();   // if  null return not found 
                }
                else  // make  current  data  == Requect data  to change  it  in momery  ; 
                {
                    Current_Instractor.Name = instrutor_Req.Name;
                    Current_Instractor.Address = instrutor_Req.Address;
                    Current_Instractor.Image_URL = instrutor_Req.Image_URL;
                    Current_Instractor.CRS_ID = instrutor_Req.CRS_ID;
                    Current_Instractor.Depart_ID = instrutor_Req.Depart_ID;
                    instractorRepost.Save();   // Save  chanies  in data  base  ; 
                    return RedirectToAction("index");    // return  instractor  List  ; 
                }
            
            }

            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name", instrutor_Req.Depart_ID);  // make  viewbag  to Show  Choise  when chose  department  ; 
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name", instrutor_Req.CRS_ID);  // to Show  list  when choise  Courses  ; 

            return View(instrutor_Req);  // return view with data if  found  error ; 
        }

        public IActionResult Delete(int  ID)
        {
            Cls_Instructor _Instractor = instractorRepost.Find_Using_ID(ID);    

            if(_Instractor != null)
            {
                instractorRepost.Delete(ID);
                instractorRepost.Save(); 
                return RedirectToAction("index");
            }
            return View(); 

        }

    }
}
