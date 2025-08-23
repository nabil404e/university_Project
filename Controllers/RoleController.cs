using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using university_Project.ViewModel;

namespace university_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = viewModel.Name
                };

                IdentityResult result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    ViewBag.Success = true;
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View("CreateRole", viewModel);
        }
    }
}
