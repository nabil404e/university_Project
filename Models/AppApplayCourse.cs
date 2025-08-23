using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_Project.Models
{
    public class AppApplayCourse
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [ForeignKey(nameof(Dept_ID))]
        public int Dept_ID{ get; set; }
        public Cls_Department ?  Department { get; set; }

        [ForeignKey(nameof(Crs_ID))]
        public int Crs_ID { get; set; }
        public Cls_Course? Course { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public string Email { get; set; }

        public string Phone { get; set; }



    }
}
