using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Business.Abstract;
using Repository.Entities.DTOs;

namespace UI.WebMvcCore.Controllers
{
    [Authorize(Roles = "AKR3P,YÖNETİM")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private UsersAndRolesDto _usersAndRolesDto;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
            _usersAndRolesDto = new UsersAndRolesDto();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var result = _adminService.GetAllUsers();
            return View(result);
        }

        public IActionResult UsersDetails(string id)
        {
            return View();
        }

        public IActionResult Companies()
        {
            return View();
        }

        [Route("EditUserCompany")]
        public IActionResult EditUserCompany()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRoles()
        {
            _usersAndRolesDto.AspNetUsers = _adminService.GetAllUsers();
            _usersAndRolesDto.AspNetRoles = _adminService.GetAllRoles();
            _usersAndRolesDto.AspNetUserRoles = _adminService.GetAllUserRoles();
            return View(_usersAndRolesDto);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult UserRoles(string userId, string roleId)
        {
            _usersAndRolesDto.AspNetUsers = _adminService.GetAllUsers();
            _usersAndRolesDto.AspNetRoles = _adminService.GetAllRoles();
            _usersAndRolesDto.AspNetUserRoles = _adminService.GetAllUserRoles();
            if (userId != null && roleId != null)
            {
                var sorgu = _usersAndRolesDto.AspNetUserRoles.Find(x => x.UserId == userId);
                _adminService.Delete(sorgu);

                sorgu.RoleId = roleId;

                _adminService.Add(sorgu);
                ViewBag.kayitDurum = true;
            }
            else
            {
                NotFound();
            }

            return View(_usersAndRolesDto);
        }

        public IActionResult DeleteCompany()
        {
            return Json("");
        }

        [HttpGet("DeleteUser")]
        public IActionResult DeleteUser(string id)
        {
            return Json("");
        }
    }
}