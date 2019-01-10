using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SportSY.Client.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {

        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public int AccessFailedCount { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public Guid PersonId { get; set; }
    }

    public class Role : IdentityRole<Guid> { }
    public class UserRole : IdentityUserRole<Guid> { }
    public class Claim: IdentityUserClaim<Guid> { }

    public class UserLogin : IdentityUserLogin<Guid> { }

    public class RoleClaim: IdentityRoleClaim<Guid> { }
        public class UserToken: IdentityUserToken<Guid> { }
}
