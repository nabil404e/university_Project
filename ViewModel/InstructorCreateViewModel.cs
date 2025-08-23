using Microsoft.AspNetCore.Mvc.Rendering;
using university_Project.Models;

public class InstructorCreateViewModel
{
    public string InstructorName { get; set; }


    public List<Cls_Department> Departments { get; set; }


    public List<Cls_Course> Courses { get; set; }
}
