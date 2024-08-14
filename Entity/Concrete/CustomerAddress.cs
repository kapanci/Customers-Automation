using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class CustomerAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AddressName { get; set; } // Name of the address (e.g., Home, Office)
        public string City { get; set; } // City
        public string District { get; set; } // District
        public string Neighborhood { get; set; } // Neighborhood
        public string Street { get; set; } // Street
        public string BuildingNumber { get; set; } // Building Number
        public string ApartmentNumber { get; set; } // Apartment Number
        public string PostalCode { get; set; } // Postal Code
        public string FullAddress { get; set; } // Full Address

        // Foreign key linking to the Customer entity
        public int CustomerId { get; set; }

        // Navigation property for the related Customer
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }

}
