using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Models;

namespace Test2.Configurations
{
    public class ServiceTypeDictInspectionEntityConfiguration: IEntityTypeConfiguration<ServiceTypeDictInspection>
    {
        public void Configure(EntityTypeBuilder<ServiceTypeDictInspection> builder)
        {
            builder.ToTable("ServiceTypeDict_Inspection");

            builder.HasKey(e => new { e.IdServiceType, e.IdInspection });

            builder.Property(e => e.Comments).HasMaxLength(300);

            builder.HasOne(e => e.IdServiceTypeDictNavigation)
                .WithMany(m => m.ServiceTypeDictInspections)
                .HasForeignKey(m => m.IdServiceType)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IdInspectionNavigation)
                .WithMany(m => m.ServiceTypeDictInspections)
                .HasForeignKey(m => m.IdInspection)
                .OnDelete(DeleteBehavior.Restrict);

            var serviceTypeDictInspections = new List<ServiceTypeDictInspection>();

            serviceTypeDictInspections.Add(new ServiceTypeDictInspection
            {
                IdServiceType = 1,
                IdInspection = 1,
                Comments = "123"
            });

            serviceTypeDictInspections.Add(new ServiceTypeDictInspection
            {
                IdServiceType = 1,
                IdInspection = 2,
                Comments = "123"
            });

            serviceTypeDictInspections.Add(new ServiceTypeDictInspection
            {
                IdServiceType = 2,
                IdInspection = 3,
                Comments = "123"
            });

            serviceTypeDictInspections.Add(new ServiceTypeDictInspection
            {
                IdServiceType = 3,
                IdInspection = 4,
                Comments = "123"
            });

            builder.HasData(serviceTypeDictInspections);
        }
    }
}
