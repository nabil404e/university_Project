using university_Project.Models;

namespace university_Project.Repostitray
{
    public class ResultRepostriy : iResult
    {

        university_DB_dbContext dbContext; 

        public ResultRepostriy(university_DB_dbContext _dbContext)
        {
            dbContext = _dbContext; 
        }
        public void Add(Cls_CRS_Result Result)
        {
            dbContext.Add(Result);
            
        }

        public bool Delete(int ID)
        {
            Cls_CRS_Result _Result = Find_Using_ID(ID);

            if (_Result != null)
            {
                dbContext.Remove(_Result);
                return true;

            }
            return false;
        }

        public void Edit(Cls_CRS_Result Result)
        {
            dbContext.Update(Result);
        }

        public Cls_CRS_Result Find_Using_ID(int ID)
        {
            return dbContext.Results.FirstOrDefault(R => R.ID ==ID); 
        }

        public List<Cls_CRS_Result> Get_All()
        {
            return dbContext.Results.ToList(); 
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}