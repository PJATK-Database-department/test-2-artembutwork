using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Models;

namespace Test2.Configurations
{
    public class ServiceTypeDictEntityConfiguration: IEntityTypeConfiguration<ServiceTypeDict>
    {
        public void Configure(EntityTypeBuilder<ServiceTypeDict> builder)
        {
            builder.ToTable("ServiceTypeDict");

            builder.HasKey(e => e.IdServiceType);
            builder.Property(e => e.IdServiceType).ValueGeneratedOnAdd();
            builder.Property(e => e.ServiceType).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Price).IsRequired().HasColumnType("decimal");         

            var services = new List<ServiceTypeDict>();

            services.Add(new ServiceTypeDict
            {
                IdServiceType = 1,
                ServiceType = "A",
                Price = 100.0
            });

            services.Add(new ServiceTypeDict
            {
                IdServiceType = 2,
                ServiceType = "B",
                Price = 200.0
            }); ;

            services.Add(new ServiceTypeDict
            {
                IdServiceType = 3,
                ServiceType = "C",
                Price = 300.0
            }); ;

            builder.HasData(services);
        }
    }
}
