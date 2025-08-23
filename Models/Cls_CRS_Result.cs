using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_Project.Models
{
    public class Cls_CRS_Result
    {

        public int ID { get; set; }
        public double Degree { get; set; }

        public int Crs_ID { get; set; }
        [ForeignKey("Crs_ID")]
        public Cls_Course? Course { get; set; }

        public int Trainee_ID { get; set; }

        [ForeignKey("Trainee_ID")]
        public Cls_Trainer? Trainer { get; set; }



    }
}
