using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using university_Project.Models;
namespace university_Project.Models
{
    public class Cls_Course
    {
        public int ID { get; set; }
        //[UniqueCourseName]

        [Required(ErrorMessage = "Course name is required")]
        [Remote(action: "IS_Valid_Name", controller: "Course", AdditionalFields = nameof(ID), ErrorMessage ="Name Must be  Unique")]
        public string Name { get; set; }




        [Range(50 , 100)]
        public double Degree { get; set; }

        //[Range(20 , 50)]

        [Remote(action: "IS_Valid_MIn_Degree", controller: "Course", ErrorMessage = "Minimum degree must be between 20 and 50.")]
        public double Min_Degree { get; set; }



        public int Depart_ID { get; set; }
        [ForeignKey("Depart_ID")]
        public Cls_Department? Department { get; set; }


        // Navigation
        public ICollection<Cls_CRS_Result>? CourseResults { get; set; }
    }

}


