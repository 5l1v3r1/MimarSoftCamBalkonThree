using Repository.Entities.Concrete;
using System.Collections.Generic;

namespace UI.WebMvcCore.Models.ViewModels
{
    public class HomeViewModel
    {
        public IList<ProductType> ProductTypes { get; set; }
    }
}