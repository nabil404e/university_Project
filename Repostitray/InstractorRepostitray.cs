using university_Project.Models;

namespace university_Project.Repostitray
{
    public class InstractorRepostitray : Instractor
    {

        university_DB_dbContext context;
        public InstractorRepostitray(university_DB_dbContext _dbContext)
        {
            context = _dbContext; 
        }
        public void Add(Cls_Instructor cls_Instructor)
        {
            context.Add(cls_Instructor);
        }

        public bool Delete(int ID)
        {
            Cls_Instructor instructor = Find_Using_ID(ID);  

            if(instructor != null)
            {
                context.Remove(instructor);
                return true;
            }
            return false;
        }

        public void Edit(Cls_Instructor cls_Instructor)
        {
            context.Update(cls_Instructor); 
        }



        public Cls_Instructor Find_Using_ID(int ID)
        {
            return  context.Instrutors.FirstOrDefault(e => e.ID == ID);

        }

        public List<Cls_Instructor> Get_All()
        {
            return context.Instrutors.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
