using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICOnboardingP1.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ProductSold ProductSold { get; set; }
    }
}