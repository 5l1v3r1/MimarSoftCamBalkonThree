using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Abstaract
{
    public abstract class PersonelBase
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string AspNetUserId { get; set; }

        [Column("Phone_Mobile")]
        [StringLength(13)]
        public string PhoneMobile { get; set; }

        public bool IsActive { get; set; }

        [Column("Date_Register", TypeName = "date")]
        public DateTime DateRegister { get; set; }
    }
}