using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleAssingController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var role = _roleManager.Roles.ToList();
            var userroles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var x in role)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = x.Id;
                model.RoleName = x.Name;
                model.RoleExist = userroles.Contains(x.Name);
                roleAssignViewModels.Add(model);
            }

            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
        { // kullanıcı bazi değerleri seçip bazılarını seçmeyeceği için list formatında değer aldık

            var userid = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var x in roleAssignViewModel)
            {
                if (x.RoleExist==true)
                {
                    await _userManager.AddToRoleAsync(user, x.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, x.RoleName);
                }
            }

            return RedirectToAction("Index");

        }
    }
}
