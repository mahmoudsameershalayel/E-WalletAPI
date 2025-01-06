using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.DBEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? CompName { get; set; }

        public string? Phone1 { get; set; }

        public string? Phone2 { get; set; }

        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;

        public string? LocationLong { get; set; }

        public string? LocationLat { get; set; }
        public bool? IsBlocked { get; set; }
        public string? FCMToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
