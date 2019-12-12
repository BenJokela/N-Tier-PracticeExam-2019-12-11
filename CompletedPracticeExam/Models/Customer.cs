using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "The CustomerID must be exactly 5 letters")]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The Company Name can be no more than 40 characters")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The Contact Name can be no more than 30 characters")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The Contact Title can be no more than 30 characters")]
        public string ContactTitle { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "The Address can be no more than 60 characters")]
        public string Address { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The City can be no more than 15 characters")]
        public string City { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The Region can be no more than 15 characters")]
        public string Region { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The Postal Code can be no more than 10 characters")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The Country can be no more than 15 characters")]
        public string Country { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "The Phone can be no more than 24 characters")]
        public string Phone { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "The Fax can be no more than 24 characters")]
        public string Fax { get; set; }


    }
}
