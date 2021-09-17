using Core.Entities;
using Repository.Entities.Abstaract;
using System.Collections.Generic;

namespace Repository.Entities.Concrete
{
    public class Producer : CompanyBase, IEntity
    {
        public Producer()
        {
            ProducerPersonels = new HashSet<ProducerPersonel>();
            Dealers = new HashSet<Dealer>();
            Orders = new HashSet<Order>();
        }

        public virtual ICollection<Dealer> Dealers { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ProducerPersonel> ProducerPersonels { get; set; }
    }
}