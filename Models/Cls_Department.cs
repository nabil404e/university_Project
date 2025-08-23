using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_Project.Models
{
    public class Cls_Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        // Navigation
        public ICollection<Cls_Course> Courses { get; set; }
        public ICollection<Cls_Trainer> Trainers { get; set; }
        public ICollection<Cls_Instructor> Instructors { get; set; }
    }
}
