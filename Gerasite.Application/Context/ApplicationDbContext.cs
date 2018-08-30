using Gerasite.Application.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Gerasite.Application.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("GerasiteConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
