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
        public Guid PersonId { get; set; }

    }

    public class Role : IdentityRole<Guid> { }
    public class UserRole : IdentityUserRole<Guid> { }
    public class Claim: IdentityUserClaim<Guid> { }

    public class UserLogin : IdentityUserLogin<Guid> { }

    public class RoleClaim: IdentityRoleClaim<Guid> { }
        public class UserToken: IdentityUserToken<Guid> { }
}
