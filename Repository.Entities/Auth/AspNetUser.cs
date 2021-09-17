using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Auth
{
    [Index(nameof(NormalizedEmail), Name = "EmailIndex")]
    public partial class AspNetUser : IdentityUser, IEntity
    {
        [StringLength(32)]
        public string FirstName { get; set; }

        [StringLength(32)]
        public string LastName { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime AccountCreated { get; set; }

        public DateTime LastLogin { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool Status { get; set; }

        public bool IsBlocked { get; set; }

        [InverseProperty("AspNetUser")]
        public virtual DealerPersonel DealerPersonel { get; set; }

        [InverseProperty("AspNetUser")]
        public virtual ProducerPersonel ProducerPersonel { get; set; }
    }
}