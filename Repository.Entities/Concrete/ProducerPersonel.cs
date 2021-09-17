using Core.Entities;
using Repository.Entities.Abstaract;
using Repository.Entities.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Concrete
{
    public class ProducerPersonel : PersonelBase, IEntity
    {
        public int ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        [InverseProperty("ProducerPersonels")]
        public virtual Producer Producer { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}