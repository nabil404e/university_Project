using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using university_Project.Models;
using university_Project.Repostitray;

namespace university_Project.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ResultController : Controller
    {
        iResult resultrepostriy;
        ICouresRepostitray coursesRepostit;
        iTrainer trainerReposit; 


        public ResultController(iResult result_repo , ICouresRepostitray couresRepo , iTrainer Trainer_Repo )
        {
            resultrepostriy = result_repo;
            coursesRepostit = couresRepo;
            trainerReposit = Trainer_Repo; 
        }
        public IActionResult Index()
        {
            var trainers = (from t in resultrepostriy.Get_All()
                            join c in coursesRepostit.Get_All()
                                on t.Crs_ID equals c.ID into courseGroup
                            from c in courseGroup.DefaultIfEmpty()
                            join tr in trainerReposit.Get_All()
                                on t.Trainee_ID equals tr.ID into trainerGroup
                            from tr in trainerGroup.DefaultIfEmpty()
                            select new TrainerResultViewModel
                            {
                                ID = t.ID , 
                                TrainerID = tr?.ID ?? 0,
                                TrainerName = tr?.Name ?? "No Trainer",
                                CourseName = c?.Name ?? "No Course",
                                Degree = t.Degree,
                                Status = (c != null && t.Degree != null)
                                            ? (t.Degree >= c.Min_Degree ? "successful" : "failed")
                                            : "No Result"
                            }).ToList();


            return View(trainers); // List<TrainerResultViewModel>
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(coursesRepostit.Get_All(), "ID", "Name");
            ViewBag.Trainers = new SelectList(trainerReposit.Get_All(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cls_CRS_Result REQ_CRS)
        {
            if (ModelState.IsValid)
            {

                resultrepostriy.Add(REQ_CRS);
                resultrepostriy.Save(); 
                return RedirectToAction("Index");
            }

            // Re-populate dropdowns
            ViewBag.Courses = new SelectList(coursesRepostit.Get_All(), "ID", "Name", REQ_CRS.Crs_ID);
            ViewBag.Trainers = new SelectList(trainerReposit.Get_All(), "ID", "Name", REQ_CRS.Trainee_ID);

            return View(REQ_CRS);
        }


        [HttpGet]
        public  IActionResult Edit ( int  ID)
        {

            Cls_CRS_Result Resulat = resultrepostriy.Find_Using_ID(ID);

            if(Resulat == null)
            {
                return NotFound(); 

            }

            ViewBag.Courses = new SelectList(coursesRepostit.Get_All(), "ID", "Name", Resulat.Crs_ID);
            ViewBag.Trainers = new SelectList(trainerReposit.Get_All(), "ID", "Name", Resulat.Trainee_ID);



            return View(Resulat); 

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit( Cls_CRS_Result REQ_CRS , int  ID  )
        {

            Cls_CRS_Result cls_CRS_ = resultrepostriy.Find_Using_ID(ID);
            if(ModelState.IsValid)
            {
                cls_CRS_.Crs_ID = REQ_CRS.Crs_ID;
                cls_CRS_.Trainee_ID = REQ_CRS.Trainee_ID; 

                cls_CRS_.Degree = REQ_CRS.Degree;

                cls_CRS_.Trainer.ID  = cls_CRS_.Trainer.ID;

                resultrepostriy.Save(); 

                return RedirectToAction("Index"); 

            }

            ViewBag.Courses = new SelectList(coursesRepostit.Get_All(), "ID", "Name", REQ_CRS.Crs_ID);
            ViewBag.Trainers = new SelectList(trainerReposit.Get_All(), "ID", "Name", REQ_CRS.Trainee_ID);



            return View(REQ_CRS);


        }

        [HttpGet]
        public  IActionResult Delete (int  ID  )
        {

             
            if(resultrepostriy.Delete(ID) == true)
            {
                resultrepostriy.Save(); 
                return RedirectToAction("Index");

            }
                
            return NotFound();  
            }


    }


    
}
