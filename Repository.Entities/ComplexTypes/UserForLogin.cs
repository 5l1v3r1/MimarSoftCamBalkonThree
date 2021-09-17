using Core.Entities;

namespace Repository.Entities.ComplexTypes
{
    public class UserForLogin : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}