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
using EFCorePro.Models.UnionTable;
using EFCorePro.Models.MVCModel;

namespace EFCorePro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserRoleRelationship> UserRoleRelationship { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FirstTable> FirstTable { get; set; }
        public DbSet<SecondTable> SecondTable { get; set; }
        public DbSet<MVCModel> MVCModel { get; set; }
        public DbSet<Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<TodoItem>()
                   .Property(t => t.Id)
                   .HasValueGenerator<IDValueGenerator>();
            builder.Entity<Article>()
                   .HasMany(a => a.ArticleTags)
                   .WithOne(a => a.Article);
            builder.Entity<Tag>()
                   .HasMany(t => t.ArticleTags)
                   .WithOne(t => t.Tag);

            builder.Query<ToDoItemVM>();
        }
    }
}
