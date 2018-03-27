using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Role : IdentityRole<int>
    {
    }

    public class RoleClaim : IdentityRoleClaim<int>
    {
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class User_Role : IdentityUserRole<int>
    {
    }
}
