using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    class Address
    {
        public long AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string BoxNumber { get; set; }
        public long LocalityIdAddress { get; set; }

        public Locality LocalityIdAddressNavigation { get; set; }
    }
}
