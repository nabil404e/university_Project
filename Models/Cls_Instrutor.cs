using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace university_Project.Models
{
    public class Cls_Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image_URL { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }

        public int Depart_ID { get; set; }
        [ForeignKey("Depart_ID")]
        public Cls_Department? Department { get; set; }

        public int CRS_ID { get; set; }
        [ForeignKey("CRS_ID")]
        public Cls_Course? Course { get; set; }
    }
}
