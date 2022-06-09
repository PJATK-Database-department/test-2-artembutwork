using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Models;

namespace Test2.Configurations
{
    public class InspectionEntityConfiguration : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.ToTable("Inspection");

            builder.HasKey(e => e.IdInspection);
            builder.Property(e => e.IdInspection).ValueGeneratedOnAdd();
            builder.Property(e => e.InspectionDate).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.Comment).HasMaxLength(300);

            builder.HasOne(e => e.IdCarNavigation)
                .WithMany(m => m.Inspections)
                .HasForeignKey(m => m.IdCar)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IdMechanicNavigation)
                .WithMany(m => m.Inspections)
                .HasForeignKey(m => m.IdMechanic)
                .OnDelete(DeleteBehavior.Restrict);

            var inspections = new List<Inspection>();

            inspections.Add(new Inspection
            {
                IdInspection = 1,
                IdCar = 1,
                IdMechanic = 1,
                InspectionDate = DateTime.Now,
                Comment = "123"
            });

            inspections.Add(new Inspection
            {
                IdInspection = 2,
                IdCar = 1,
                IdMechanic = 2,
                InspectionDate = DateTime.Now.AddDays(1),
                Comment = "123"
            });

            inspections.Add(new Inspection
            {
                IdInspection = 3,
                IdCar = 2,
                IdMechanic = 2,
                InspectionDate = DateTime.Now.AddDays(2),
                Comment = "123"
            });

            inspections.Add(new Inspection
            {
                IdInspection = 4,
                IdCar = 3,
                IdMechanic = 3,
                InspectionDate = DateTime.Now.AddDays(3),
                Comment = "123"
            });

            builder.HasData(inspections);
        }
    }
}
