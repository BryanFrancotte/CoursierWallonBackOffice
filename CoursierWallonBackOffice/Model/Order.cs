using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    class Order
    {
        public Order()
        {
            Letter = new HashSet<Letter>();
            Parcel = new HashSet<Parcel>();
        }

        public long OrderNumber { get; set; }
        public string State { get; set; }
        public DateTime PickUpDate { get; set; }
        public string PickUpStartTime { get; set; }
        public string PickUpEndTime { get; set; }
        public string PickUpTime { get; set; }
        public DateTime DepositDate { get; set; }
        public string DepositStartTime { get; set; }
        public string DepositEndTime { get; set; }
        public string DepositTime { get; set; }
        public int DeliveryType { get; set; }
        public decimal? Price { get; set; }
        public string UserIdOrder { get; set; }
        public string CoursierIdOrder { get; set; }
        public long PickUpAddress { get; set; }
        public long DepositAddress { get; set; }
        public long BillingAddress { get; set; }
        public byte[] VerCol { get; set; }

        public Address BillingAddressNavigation { get; set; }
        public ApplicationUser CoursierIdOrderNavigation { get; set; }
        public Address DepositAddressNavigation { get; set; }
        public Address PickUpAddressNavigation { get; set; }
        public ApplicationUser UserIdOrderNavigation { get; set; }
        public ICollection<Letter> Letter { get; set; }
        public ICollection<Parcel> Parcel { get; set; }

        public int GetNbItems()
        {
            return Letter.Count() + Parcel.Count();
        }
    }
}
