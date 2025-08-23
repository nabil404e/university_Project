using university_Project.Models;

namespace university_Project.Repostitray
{
    public interface iDepartment
    {

        void Add(Cls_Department cls_Department);
        void Edit(Cls_Department cls_Instructor);
        bool Delete(int ID);


        List<Cls_Department> Get_All();

        Cls_Department Find_Using_ID(int ID);


        void Save();
    }
}
