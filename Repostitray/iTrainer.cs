using university_Project.Models;

namespace university_Project.Repostitray
{
    public interface iTrainer
    {
        void Add(Cls_Trainer cls_Trainer);
        void Edit(Cls_Trainer cls_Trainer);
        bool Delete(int ID);


        List<Cls_Trainer> Get_All();

        Cls_Trainer Find_Using_ID(int ID);


        void Save();
    }
}
