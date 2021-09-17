using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public partial class Product : IEntity
    {
        public Product()
        {
            ProductParts = new HashSet<ProductPart>();
        }

        [Key]
        public int ProductId { get; set; }

        public short TypeId { get; set; }

        public int DealerId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string PathPDF { get; set; }

        [ForeignKey(nameof(DealerId))]
        [InverseProperty("Products")]
        public virtual Dealer Dealer { get; set; }

        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(ProductType.Products))]
        public virtual ProductType Type { get; set; }

        [InverseProperty(nameof(ProductPart.Product))]
        public virtual ICollection<ProductPart> ProductParts { get; set; }

        public virtual Order Order { get; set; }
    }
}