using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address.Domain.Entities
{
    public class Address
    {
		public int Id { get; set; }
		public string Street { get; set; }
		public string HouseNumber { get; set; }
		public string HouseNumberAddition { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
    }
}
