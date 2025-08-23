using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Marshalling;
using university_Project.Models;

namespace university_Project.Repostitray 
{
    public class TrainerRepositry : iTrainer
    {

        university_DB_dbContext dbContext; 
        public TrainerRepositry (university_DB_dbContext _dbContext)
        {
            dbContext = _dbContext; 

        }

        public void Add(Cls_Trainer cls_Trainer)
        {
            dbContext.Add (cls_Trainer);
        }

        public bool Delete(int ID)
        {
            Cls_Trainer _Trainer = Find_Using_ID(ID);
            if(_Trainer != null)
            {
                dbContext.Remove (_Trainer);
                return true;

            }
            return false;   


        }

        public void Edit(Cls_Trainer cls_Trainer)
        {
            dbContext.Update (cls_Trainer);
        }

        public Cls_Trainer Find_Using_ID(int ID)
        {
            return dbContext.Trainers.FirstOrDefault(e => e.ID == ID);
        }

        public List<Cls_Trainer> Get_All()
        {
            return dbContext.Trainers.Include(e=> e.Department).Include(e=> e.result).Include(e=> e.Course).ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();    
        }
    }
}
