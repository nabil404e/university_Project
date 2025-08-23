using System.ComponentModel.DataAnnotations;

namespace university_Project.Models
{
    public class UniqueCourseNameAttribute : ValidationAttribute
    {
       
        protected override ValidationResult? IsValid(object? value,   ValidationContext validationContext)
        {

            if(value == null)   // check if  value  null 
            {
                return null;   
            }
            string Name  = value.ToString();
           
            // to save  copy  of  request value to compere  it  if  unique  or  not  

            university_DB_dbContext dbContext = new university_DB_dbContext();   // make  context  from data  base  to select  from it  

            Cls_Course Couse  = dbContext.Courses.FirstOrDefault(c => c.Name == Name );   // Try  to find Cousrse Name  

            if(Couse != null)  // check if  it  found  or  not  
            {
                return new ValidationResult("Course  Name  must  Unique");   // Error  massage  it  is  Showen when error  accrued 
            }

            return ValidationResult.Success;  // return Validation do Secuess  ;  


        }

    }
}
