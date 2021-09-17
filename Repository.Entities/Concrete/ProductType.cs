using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public partial class ProductType : IEntity
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public short Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [InverseProperty(nameof(Product.Type))]
        public virtual ICollection<Product> Products { get; set; }
    }
}