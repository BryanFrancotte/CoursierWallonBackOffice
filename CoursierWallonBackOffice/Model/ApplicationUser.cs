using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Model
{
    class ApplicationUser
    {
        public string Id { get; set; }
        public long? AddressIdUser { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[] VerCol { get; set; }
        public Address AddressIdUserNavigation { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
