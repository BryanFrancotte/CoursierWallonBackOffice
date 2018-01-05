using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public byte[] VerCol { get; set; }
        public string UserName { get; set; }

        public string AndroidToken { get; set; }
    }
}
