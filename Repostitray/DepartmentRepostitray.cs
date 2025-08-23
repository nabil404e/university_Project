using university_Project.Models;

namespace university_Project.Repostitray
{
    public class DepartmentRepostitray : iDepartment
    {

        university_DB_dbContext dbContext;

        public DepartmentRepostitray(university_DB_dbContext _dbContext)
        {
            dbContext = _dbContext; 
        }
        public void Add(Cls_Department OBJ_Course)
        {
            dbContext.Add(OBJ_Course);
            
        }

        public bool Delete(int ID)
        {
            Cls_Department department = Find_Using_ID(ID);
            if (department != null)
            {
                dbContext.Remove(department);
                return true;
            }
            return false;
        }

        public void Edit(Cls_Department OBJ_Course)
        {
            dbContext.Update(OBJ_Course); 
        }

        public Cls_Department Find_Using_ID(int ID)
        {
            Cls_Department _Department = dbContext.Departments.FirstOrDefault(e => e.ID == ID);

            return _Department; 
        }

        public List<Cls_Department> Get_All()
        {
            return dbContext.Departments.ToList();  
        }

        public void Save()
        {
            dbContext.SaveChanges(); 
        }
    }
}
