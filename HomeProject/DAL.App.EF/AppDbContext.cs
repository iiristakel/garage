using System.Linq;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillLine> BillLines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductForClient> ProductsForClients { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserPosition> AppUsersPositions { get; set; }
        public DbSet<AppUserOnObject> AppUsersOnObjects { get; set; }
        public DbSet<WorkObject> WorkObjects { get; set; }
        public DbSet<AppUserInPosition> AppUsersInPositions { get; set; }
        public DbSet<ProductService> ProductsServices { get; set; }

        
        public DbSet<MultiLangString> MultiLangStrings { get; set; }
        public DbSet<Translation> Translations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }

}