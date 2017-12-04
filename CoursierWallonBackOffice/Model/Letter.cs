using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    class Letter
    {
        public long LetterId { get; set; }
        public bool IsImportant { get; set; }
        public long OrderNumberLetter { get; set; }
    }
}
