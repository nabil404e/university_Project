using university_Project.Models;

namespace university_Project.Repostitray
{
    public class CoursesRepostitray : ICouresRepostitray
    {


        university_DB_dbContext dbContext;


        public  CoursesRepostitray(university_DB_dbContext _dbContext)
        {
            dbContext = _dbContext; 
        }

        public void  Add (Cls_Course OBJ_Course)
        {

            dbContext.Add (OBJ_Course);

        }

        public  void Edit(Cls_Course OBJ_Course)
        {
            dbContext.Update (OBJ_Course);

        }

        public  bool  Delete(int  ID  )
        {

            Cls_Course _Course = Find_Using_ID(ID);

            if (_Course != null)
            {
                dbContext.Remove(_Course);
                return true; 
            }
            return false;
        }

        public Cls_Course  Find_Using_ID(int  ID  )
        {
            return
                
                 dbContext.Courses.FirstOrDefault (c => c.ID == ID);
            

        }

        public List<Cls_Department>  Find_Using_Daepartment(int ID)
        {
            return dbContext.Departments.Where(e => e.ID == ID).ToList(); 
        }

        public List<Cls_Course> Get_All()
        {
            return dbContext.Courses.ToList (); 
        }

        public void Save()
        {
            dbContext.SaveChanges ();   
        }


        public bool IS_Valid_Name(string Name   ,int  ID  )
        {
            bool exists = dbContext.Courses.Any(e => e.Name == Name && e.ID != ID);

            return exists;
        }
    }
}
