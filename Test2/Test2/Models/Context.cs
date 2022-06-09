using Microsoft.EntityFrameworkCore;
using Test2.Configurations;

namespace Test2.Models
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<ServiceTypeDict> ServiceTypeDict { get; set; }
        public virtual DbSet<Mechanic> Mechanic { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Inspection> Inspection { get; set; }
        public virtual DbSet<ServiceTypeDictInspection> ServiceTypeDictInspection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s22841;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceTypeDictEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MechanicEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeDictInspectionEntityConfiguration());
        }
    }
}
