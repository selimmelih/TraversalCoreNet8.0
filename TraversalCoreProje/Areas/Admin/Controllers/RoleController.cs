using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [Route("AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }

        [Route("AddRole")]
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole role = new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            else
            {
                return View(result);
            }
        }
    }
}
