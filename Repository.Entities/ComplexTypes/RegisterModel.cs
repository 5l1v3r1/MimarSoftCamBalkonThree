using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities.ComplexTypes
{
    public class RegisterModel
    {
        [Required] public string UserName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Required] public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MobileNumber { get; set; }
    }
}