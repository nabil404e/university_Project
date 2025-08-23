using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace university_Project.Models
{
    public class ErrorHandeler : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            // Make  eroro massage  as  string  data  content  ; 

            //ContentResult content = new ContentResult();   // make  content  to show to continue  error Massage  
            //content.Content = "Some Exception Throw";    // Include  Error  massage  
            //context.Result  = content;    // make  context  = content  resulat  , 


            // Make  it  to return view 

            ViewResult viewResult = new ViewResult();   // Make  new  view  result  becouse  it  not  inhert controller  so it  cant  return view  must  declurate it  

            viewResult.ViewName = "Error";    // to declirae  viewmodel name  , 

            context.Result = viewResult;      // make  context  = view to return it  , 

        }
    }
}
