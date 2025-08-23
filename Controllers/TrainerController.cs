using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using university_Project.Models;
using university_Project.Repostitray;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace university_Project.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class TrainerController : Controller
    {

         iTrainer TrainerReposit;

        iDepartment departmentRepost;

        ICouresRepostitray CoursesRepost;

        iResult ResultRepost; 


        public TrainerController(iTrainer Trainerrepo , iDepartment departmentrepo , ICouresRepostitray couresrepo  , iResult resultrepo)
        {
            TrainerReposit = Trainerrepo;
            departmentRepost = departmentrepo;
            CoursesRepost= couresrepo;

            ResultRepost = resultrepo; 
        }

        public IActionResult Index()
        {
            // Load all trainers with related data
            var Trainer = TrainerReposit.Get_All()
                .Select(t=>  new TrainerViewModel
                {
                    ID = t.ID,
                    Name = t.Name,
                    Address = t.Address,
                    Department = t.Department ,
                    Course =t.Course , 
                    Result = t.result
                }).ToList();    

            return View("Show_All_Tranir" ,Trainer);
        }
        
        [HttpGet]
        public  IActionResult Create()
        {
            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name");
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name"); ; // for dropdown

            return View("Create");
        }
        
        [HttpPost] // 👈 Explicitly mark POST
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Cls_Trainer ReqTranier)
        {
            if(ModelState.IsValid)
            {
                // Set resultID to null initially (no result yet)
                ReqTranier.resultID =null;
                
                TrainerReposit.Add(ReqTranier);
                TrainerReposit.Save();

                return RedirectToAction("index"); 
            }
            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name");
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name"); // for dropdown

            return View(ReqTranier); 
        }

        [HttpGet]
        public IActionResult Edit(int  ID  )
        {
            Cls_Trainer OBj_Trainer = TrainerReposit.Find_Using_ID(ID);

            if(OBj_Trainer == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name");
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name"); // for dropdown

            return View(OBj_Trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cls_Trainer REQ_Trainer, int ID)
        {
            var OBj_Trainer = TrainerReposit.Find_Using_ID(ID);  

            if (OBj_Trainer == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                OBj_Trainer.Name = REQ_Trainer.Name;
                OBj_Trainer.Address = REQ_Trainer.Address;
                OBj_Trainer.Grade = REQ_Trainer.Grade;
                OBj_Trainer.DepartmentID = REQ_Trainer.DepartmentID; // use FK, not Department object
                OBj_Trainer.ImageURL = REQ_Trainer.ImageURL;
                OBj_Trainer.CourseID = REQ_Trainer.CourseID;

                TrainerReposit.Save();  // no Add here
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(departmentRepost.Get_All(), "ID", "Name", REQ_Trainer.DepartmentID);
            ViewBag.Courses = new SelectList(CoursesRepost.Get_All(), "ID", "Name" ,REQ_Trainer.CourseID); // for dropdown

            return View(REQ_Trainer);
        }

        public IActionResult Delete(int  ID )
        {
            
            if(TrainerReposit.Delete(ID) == true )
            {
                TrainerReposit.Save(); 
          
                return RedirectToAction("Index");
            }
            return View(); 
        }


        [HttpGet]
        public IActionResult Show_Results(int id)
        {
            var trainer = (from t in TrainerReposit.Get_All()
                           join c in TrainerReposit.Get_All()
                               on t.CourseID equals c.ID into courseGroup
                           from c in courseGroup.DefaultIfEmpty()
                           join r in ResultRepost.Get_All() 
                               on t.resultID equals r.ID into resultGroup
                           from r in resultGroup.DefaultIfEmpty()
                           where t.ID == id
                           select new TrainerResultViewModel
                           {
                               TrainerID = t.ID,
                               ID = r != null ? r.ID : 0,
                               TrainerName = t.Name,
                               CourseName = c != null ? c.Course.Name : "No Course",
                               Degree = r != null && r.Degree != null ? r.Degree : 0, // Safe for null
                               Status = (r != null && r.Degree !=null && c != null && c.Course.Min_Degree !=null)
                                        ? (r.Degree >= c.Course.Min_Degree ? "successful" : "failed")
                                        : "No Result"
                           })
                          .FirstOrDefault();

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        [HttpGet]
        public IActionResult Find(int id)
        {
            Cls_Trainer _Trainer = TrainerReposit.Find_Using_ID(id);    
            if (_Trainer == null)
            {
                return NotFound();
            }

            return Show_Results(id);
        }
    }
}
