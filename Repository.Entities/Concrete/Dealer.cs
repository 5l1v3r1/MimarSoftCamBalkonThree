using Core.Entities;
using Repository.Entities.Abstaract;
using System.Collections.Generic;

namespace Repository.Entities.Concrete
{
    public partial class Dealer : CompanyBase, IEntity
    {
        public Dealer()
        {
            DealerPersonels = new HashSet<DealerPersonel>();
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        public virtual ICollection<DealerPersonel> DealerPersonels { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}