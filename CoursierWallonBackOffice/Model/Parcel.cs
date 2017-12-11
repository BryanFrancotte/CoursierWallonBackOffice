using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    public class Parcel
    {
        public long ParcelId { get; set; }
        public int ParcelType { get; set; }
        public long OrderNumberParcel { get; set; }
        public Order OrderNumberParcelNavigation { get; set; }
    }
}
