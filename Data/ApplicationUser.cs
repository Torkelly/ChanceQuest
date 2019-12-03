using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanceQuest.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int PlayerId { get; set; }
    }
}
