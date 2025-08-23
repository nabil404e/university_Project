using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_Project.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string  Password { get; set; }
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfairmPassword { get; set; }
        public string? Address { get; set; }


    }
}
