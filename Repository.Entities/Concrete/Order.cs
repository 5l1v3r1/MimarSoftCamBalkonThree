using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ProducerId { get; set; }

        public int DealerId { get; set; }

        public int ProductId { get; set; }

        [Column("OrderDate", TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public bool IsOrderStatus { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey(nameof(DealerId))]
        [InverseProperty("Orders")]
        public virtual Dealer Dealer { get; set; }

        [ForeignKey(nameof(ProducerId))]
        [InverseProperty("Orders")]
        public virtual Producer Producer { get; set; }
    }
}