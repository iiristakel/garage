using System.Linq;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>, IDataContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillLine> BillLines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductForClient> ProductsForClients { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPosition> WorkersPositions { get; set; }
        public DbSet<WorkerOnObject> WorkersOnObjects { get; set; }
        public DbSet<WorkObject> WorkObjects { get; set; }
        public DbSet<WorkerInPosition> WorkersInPositions { get; set; }

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