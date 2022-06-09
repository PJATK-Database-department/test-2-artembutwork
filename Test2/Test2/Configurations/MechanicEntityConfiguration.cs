using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Models;

namespace Test2.Configurations
{
    public class MechanicEntityConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.ToTable("Mechanic");

            builder.HasKey(e => e.IdMechanic);
            builder.Property(e => e.IdMechanic).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);

            var mechanics = new List<Mechanic>();

            mechanics.Add(new Mechanic
            {
                IdMechanic = 1,
                FirstName = "M1",
                LastName = "1M"
            });

            mechanics.Add(new Mechanic
            {
                IdMechanic = 2,
                FirstName = "M2",
                LastName = "2M"
            });

            mechanics.Add(new Mechanic
            {
                IdMechanic = 3,
                FirstName = "M3",
                LastName = "3M"
            });

            builder.HasData(mechanics);
        }
    }
}
