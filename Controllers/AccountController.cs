using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using university_Project.Models;
using university_Project.ViewModel;

namespace university_Project.Controllers
{
    
    public class AccountController : Controller
    {
   
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager=userManager;
            this.signInManager=signInManager;
        }




        [HttpGet]
        public IActionResult SavaRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavaRegister(RegisterViewModel Register_Model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser userapp = new ApplicationUser();
                userapp.Address = Register_Model.Address;
                userapp.UserName = Register_Model.UserName;
                userapp.PasswordHash = Register_Model.Password;

                IdentityResult identityResult = await userManager.CreateAsync(userapp , Register_Model.Password);

                if (identityResult.Succeeded)
                {
                    
                    await userManager.AddToRoleAsync(userapp, "Student"); 
                    await signInManager.SignInAsync(userapp, false);
                    return RedirectToAction("Index", "ApplyCourse");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(Register_Model);
        }
        [HttpGet]
        public IActionResult SavaAdminRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SavaAdminRegister(RegisterViewModel Register_Model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userapp = new ApplicationUser
                {
                    Address = Register_Model.Address,
                    UserName = Register_Model.UserName,
      
                };

                IdentityResult identityResult = await userManager.CreateAsync(userapp, Register_Model.Password);

                if (identityResult.Succeeded)
                {
                    // لازم Role "Admin" يكون موجود قبل ده
                    await userManager.AddToRoleAsync(userapp, "Admin");
                    await signInManager.SignInAsync(userapp, false);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(Register_Model);
        }

        [HttpGet]
      
        public  IActionResult Login()
        {
            return View("SaveLogin"); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginViewModel loginViewModel)
        {
            // check found  , 
            if(ModelState.IsValid)
            {
                // Try  to find  User name  ;    
                ApplicationUser appuser = await userManager.FindByNameAsync(loginViewModel.Name); 
                if(appuser != null)
                {
                    // check password  
                    bool found = await userManager.CheckPasswordAsync(appuser, loginViewModel.Password); 
                    if(found == true)
                    { // Generate  cookie  
                        List<Claim>claims = new List<Claim>();  // make  lit to save  claims 
                        claims.Add((new  Claim ("Address", appuser.Address)));   // Add new  Claims 

                        await signInManager.SignInWithClaimsAsync(appuser, loginViewModel.RememberMe, claims);  // make cookie  whtit Claims .. 
                                                                                                                //await signInManager.SignInAsync(appuser, loginViewModel.RememberMe); 

                        if (await userManager.IsInRoleAsync(appuser, "Student"))
                        {
                            return RedirectToAction("Index", "ApplyCourse"); // Student
                        }
                        else
                        {
                            return RedirectToAction("Index", "Course"); // Admin or Employee
                        }
                    }


                }

                ModelState.AddModelError("", "User Name OR  Password  Wrong");

                
            }
            return View();


        }

        public async Task<IActionResult> SingOut()
        {
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home");  
        }
    }
}
