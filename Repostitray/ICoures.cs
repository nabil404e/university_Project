using university_Project.Models;

namespace university_Project.Repostitray
{
    public interface ICouresRepostitray
    {

        void Add(Cls_Course OBJ_Course);
        void Edit(Cls_Course OBJ_Course);
        bool  Delete(int ID);


        List<Cls_Course> Get_All(); 
       
        Cls_Course Find_Using_ID(int  ID  );


        List<Cls_Department>  Find_Using_Daepartment(int ID);
        void Save();
        bool IS_Valid_Name(string name, int iD);

    }
}
