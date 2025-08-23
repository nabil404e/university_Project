using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace university_Project.Models
{


    public class Cls_Trainer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }


        public int Grade { get; set; }

        // Navigation properties

        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Cls_Course? Course { get; set; }
        [ForeignKey("DepartmentID")]  // Match the actual DB column name
        public int DepartmentID { get; set; }

        public Cls_Department? Department { get; set; }


        public int? resultID { get; set; }

        [ForeignKey("resultID")]
        public Cls_CRS_Result? result { get; set; }

    }

}