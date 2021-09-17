using Core.Entities;
using Repository.Entities.Abstaract;
using Repository.Entities.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public partial class DealerPersonel : PersonelBase, IEntity
    {
        public int DealerId { get; set; }

        [ForeignKey(nameof(DealerId))]
        [InverseProperty("DealerPersonels")]
        public virtual Dealer Dealer { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}