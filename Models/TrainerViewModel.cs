namespace university_Project.Models
{
    public class TrainerViewModel
    {
        public int ID { get; set; }

        public string Name  { get; set; }

        public string   Address { get; set; }

        public Cls_Department Department { get; set; }


        public Cls_Course Course { get; set; }

        public Cls_CRS_Result Result { get; set; }




    }
}
