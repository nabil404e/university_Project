using System.ComponentModel.DataAnnotations.Schema;
using university_Project.Models;

namespace university_Project.ViewModel
{
    public class ApplayCourseViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public int Dept_ID { get; set; }


        public int Crs_ID { get; set; }


        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public string Email { get; set; }

        public string Phone { get; set; }


        public Cls_Course course  { get; set; }
        public Cls_Department Department { get; set; }
    }
}
