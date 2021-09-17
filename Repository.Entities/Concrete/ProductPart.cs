using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public partial class ProductPart : IEntity
    {
        [Key]
        public int Id { get; set; }

        public short CategoryId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("ProductParts")]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductParts")]
        public virtual Product Product { get; set; }

        public short Quantity { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal Size { get; set; }
    }
}