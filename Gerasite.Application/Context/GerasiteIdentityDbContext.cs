using Gerasite.Application.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Gerasite.Application.Context
{
    public class GerasiteIdentityDbContext : IdentityDbContext<UsuarioIdentity>, IDisposable
    {
        public GerasiteIdentityDbContext() : base("GerasiteConnection")
        {
        }
        static GerasiteIdentityDbContext()
        {
            Database.SetInitializer<GerasiteIdentityDbContext>(new IdentityDbInit());
        }
        public static GerasiteIdentityDbContext Create()
        {
            return new GerasiteIdentityDbContext();
        }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<GerasiteIdentityDbContext>
    {
    }
}
