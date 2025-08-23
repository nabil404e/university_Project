using university_Project.Models;

namespace university_Project.Repostitray
{
    public interface Instractor
    {
        void Add(Cls_Instructor cls_Instructor);
        void Edit(Cls_Instructor cls_Instructor);
        bool Delete(int ID);


        List<Cls_Instructor> Get_All();

        Cls_Instructor Find_Using_ID(int ID);

        void Save();
    }
}
