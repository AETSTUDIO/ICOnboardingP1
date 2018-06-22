using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICOnboardingP1.Models
{
    public class ProductSold
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Sold")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateSold { get; set; }

        [Required(ErrorMessage = "Please select customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required(ErrorMessage ="Please select product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage ="Please select store")]
        public int StoreId { get; set; }

        public Store Store { get; set; }

    }
}