using university_Project.Models;

namespace university_Project.Repostitray
{
    public interface iApplayForm
    {
        void Add(AppApplayCourse appApplayCourse);


        List<AppApplayCourse> ShowAll();

        AppApplayCourse Find_UsingID(int ID); 
        void  Update( AppApplayCourse appApplayCourse);
        
        bool   Delete( int ID );


        void Save();
    }
}
