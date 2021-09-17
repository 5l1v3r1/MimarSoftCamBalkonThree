using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public partial class Category : IEntity
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            ProductParts = new HashSet<ProductPart>();
        }

        [Key]
        public short Id { get; set; }

        public short? ParentId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(Category.InverseParent))]
        public virtual Category Parent { get; set; }

        [InverseProperty(nameof(Category.Parent))]
        public virtual ICollection<Category> InverseParent { get; set; }

        [InverseProperty(nameof(ProductPart.Category))]
        public virtual ICollection<ProductPart> ProductParts { get; set; }
    }
}