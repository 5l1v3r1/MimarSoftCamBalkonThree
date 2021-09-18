using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Business.Abstract;
using Repository.Entities.Auth;
using Repository.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.WebMvcCore.Controllers
{
    [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA")]
    public class FactoryAdminController : Controller
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        //private readonly ILogger<ChangePasswordModel> _logger;

        private readonly IAdminService _adminService;
        private UsersAndRolesDto _usersAndRolesDto;



        public FactoryAdminController(
            UserManager<AspNetUser> userManager,
            SignInManager<AspNetUser> signInManager,
            IAdminService adminService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _adminService = adminService;
            _usersAndRolesDto = new UsersAndRolesDto();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRoles()
        {
            var claims = User.Claims; // roller
            var userId = claims.First().Value; // login olan kullanici id'si

            var userRoleId = (from p in _adminService.GetAllUserRoles()
                              where p.UserId == userId
                              select p.RoleId).ToList(); // login olan kullanici roleId'leri string            

            int diziBoy = userRoleId.Count();
            int[] listRoleId = new int[diziBoy]; // int roleId dizisi

            for (int i = 0; i < diziBoy; i++)
            {
                listRoleId[i] = Convert.ToInt32(userRoleId[i]);
            }

            int minRoleId = Min(listRoleId); // login olan kullanici min roleId integer

            var AllRole = (from p in _adminService.GetAllRoles()
                           where Convert.ToInt32(p.Id) > minRoleId
                           select p).ToList();

            var AllUserRole = (from p in _adminService.GetAllUserRoles()
                               where Convert.ToInt32(p.RoleId) > minRoleId
                               select p).ToList();

            _usersAndRolesDto.AspNetUserRoles = AllUserRole;

            List<AspNetUser> userList = new List<AspNetUser>();
            foreach (var userr in AllUserRole)
            {
                var usr = _adminService.GetListUsers(x => x.Id == userr.UserId).First();
                userList.Add(usr);
            }
            _usersAndRolesDto.AspNetUsers = userList;

            List<AspNetRole> roleList = new List<AspNetRole>();
            foreach (var rl in AllRole)
            {
                var rol = _adminService.GetListRoles(x => x.Id == rl.Id).First();
                roleList.Add(rol);
            }
            _usersAndRolesDto.AspNetRoles = roleList;


            return View(_usersAndRolesDto);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult UserRoles(string userId, string roleId)
        {
            var claims = User.Claims; // roller
            var usrId = claims.First().Value; // login olan kullanici id'si

            var userRoleId = (from p in _adminService.GetAllUserRoles()
                              where p.UserId == usrId
                              select p.RoleId).ToList(); // login olan kullanici roleId'leri string            

            int diziBoy = userRoleId.Count();
            int[] listRoleId = new int[diziBoy]; // int roleId dizisi

            for (int i = 0; i < diziBoy; i++)
            {
                listRoleId[i] = Convert.ToInt32(userRoleId[i]);
            }

            int minRoleId = Min(listRoleId); // login olan kullanici min roleId integer

            var AllRole = (from p in _adminService.GetAllRoles()
                           where Convert.ToInt32(p.Id) > minRoleId
                           select p).ToList();

            var AllUserRole = (from p in _adminService.GetAllUserRoles()
                               where Convert.ToInt32(p.RoleId) > minRoleId
                               select p).ToList();

            _usersAndRolesDto.AspNetUserRoles = AllUserRole;

            List<AspNetUser> userList = new List<AspNetUser>();
            foreach (var userr in AllUserRole)
            {
                var usr = _adminService.GetListUsers(x => x.Id == userr.UserId).First();
                userList.Add(usr);
            }
            _usersAndRolesDto.AspNetUsers = userList;

            List<AspNetRole> roleList = new List<AspNetRole>();
            foreach (var rl in AllRole)
            {
                var rol = _adminService.GetListRoles(x => x.Id == rl.Id).First();
                roleList.Add(rol);
            }
            _usersAndRolesDto.AspNetRoles = roleList;

            if (usrId != null && roleId != null)
            {
                AspNetUserRole sorgu = _usersAndRolesDto.AspNetUserRoles.Find(x => x.UserId == usrId);
                _adminService.Delete(sorgu);

                sorgu.RoleId = roleId;
                _adminService.Add(sorgu);
                //_adminService.Update(sorgu);
                ViewBag.kayitDurum = true;
            }
            else
            {
                NotFound();
            }
            return View(_usersAndRolesDto);

            // ********************************************************
            //_usersAndRolesDto.AspNetUsers = _adminService.GetAllUsers();
            //_usersAndRolesDto.AspNetRoles = _adminService.GetAllRoles();
            //_usersAndRolesDto.AspNetUserRoles = _adminService.GetAllUserRoles();
            //if (usrId != null && roleId != null)
            //{
            //    AspNetUserRole sorgu = _usersAndRolesDto.AspNetUserRoles.Find(x => x.UserId == usrId);
            //    _adminService.Delete(sorgu);

            //    sorgu.RoleId = roleId;
            //    _adminService.Add(sorgu);
            //    //_adminService.Update(sorgu);
            //    ViewBag.kayitDurum = true;
            //}
            //else
            //{
            //    NotFound();
            //}

            //return View(_usersAndRolesDto);
        }

        private int Min(int[] sayilar)
        {
            int kucuk = sayilar[0];

            for (int i = 0; i < sayilar.Length; i++)
            {
                if (kucuk > sayilar[i])
                { kucuk = sayilar[i]; }
            }
            return kucuk;
        }

    }
}
