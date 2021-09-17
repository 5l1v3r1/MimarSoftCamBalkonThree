using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Abstaract
{
    public abstract class CompanyBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Title { get; set; }

        [Column("Phone_Mobile")]
        [StringLength(13)]
        public string PhoneMobile { get; set; }

        [Column("WebURL")]
        [StringLength(256)]
        public string WebUrl { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(32)]
        public string City { get; set; }

        public bool? Status { get; set; }

        public bool? IsDeleted { get; set; }

        [Column("Date_Register", TypeName = "date")]
        public DateTime DateRegister { get; set; }
    }
}