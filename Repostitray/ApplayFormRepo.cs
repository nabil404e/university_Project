using Microsoft.EntityFrameworkCore;
using university_Project.Models;

namespace university_Project.Repostitray
{
    public class ApplayFormRepo : iApplayForm
    {
        university_DB_dbContext dbContext;

        public ApplayFormRepo(university_DB_dbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public void Add(AppApplayCourse appApplayCourse)
        {
            dbContext.Add(appApplayCourse);
        
        }

        public bool Delete(int ID)
        {
            AppApplayCourse appApplay = Find_UsingID(ID);

            if(appApplay != null)
            {
                dbContext.Remove(appApplay);
                return true;
            }

            return false;
            
        }

        public AppApplayCourse Find_UsingID(int ID)
        {
            return dbContext.ApplayCourses.FirstOrDefault(e => e.ID == ID); 
        }

        public void Save()
        {
            dbContext.SaveChanges(); 
        }

        public List<AppApplayCourse> ShowAll()
        {
            return dbContext.ApplayCourses.
                Include(e => e.Department).
                Include(e => e.Course).
                ToList();    
        }

        public void Update(AppApplayCourse appApplayCourse)
        {
            dbContext.Update(appApplayCourse);
        }
    }
}
