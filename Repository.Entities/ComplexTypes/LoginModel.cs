using System.ComponentModel.DataAnnotations;

namespace Repository.Entities.ComplexTypes
{
    public class LoginModel
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
    }
}