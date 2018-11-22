using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EFCorePro.Models;
using EFCorePro.ValueGenerators;
using EFCorePro.Models.ManyToMany;
using EFCorePro.Models.MultipleColumnsSameTable;
using EFCorePro.Models.EFCore;
using System.Data.Common;
using System.Data;
using System.Reflection;
using EFCorePro.Models.LazyLoad;
using EFCorePro.Models.OneToMany;

namespace EFCorePro.Data
{
    public class EFCoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
            : base(options)
        {
        }
        public DbSet<JunctionClass> JunctionClass { get; set; }
        public DbSet<ClassA> ClassA { get; set; }

        public DbSet<ClassB> ClassB { get; set; }
        public DbSet<ItemTag> ItemTag { get; set; }
        public DbSet<Item> Item { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
