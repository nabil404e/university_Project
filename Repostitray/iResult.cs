using university_Project.Models;

namespace university_Project.Repostitray
{
    public interface iResult
    {

        void Add(Cls_CRS_Result Result);
        void Edit(Cls_CRS_Result Result);
        bool Delete(int ID);


        List<Cls_CRS_Result> Get_All();

        Cls_CRS_Result Find_Using_ID(int ID);


        void Save();

    }
}
