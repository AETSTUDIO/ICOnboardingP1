using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICOnboardingP1.Models;

namespace ICOnboardingP1.ViewModels
{
    public class SalesRecordViewModel
    {
        public ProductSold ProductSold { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Store> Stores { get; set; }
    }
}