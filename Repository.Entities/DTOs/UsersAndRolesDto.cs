using Core.Entities;
using Repository.Entities.Auth;
using System.Collections.Generic;

namespace Repository.Entities.DTOs
{
    public class UsersAndRolesDto : IDto
    {
        public List<AspNetUser> AspNetUsers { get; set; }
        public List<AspNetUserRole> AspNetUserRoles { get; set; }
        public List<AspNetRole> AspNetRoles { get; set; }
    }
}