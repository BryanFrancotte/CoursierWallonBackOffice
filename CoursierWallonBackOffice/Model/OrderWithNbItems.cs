using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    public class OrderWithNbItems
    {
        public Order Order { get; set; }
        public int NbItems { get; set; }

        public string NameCoursier { get; set; }
    }
}
