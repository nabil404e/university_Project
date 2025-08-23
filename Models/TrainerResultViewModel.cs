namespace university_Project.Models
{
    public class TrainerResultViewModel
    {

        public int ID  { get; set; }
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public string CourseName { get; set; }
        public double ? Degree { get; set; }

        public string Status { get; set; }
    }
}