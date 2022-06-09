using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Models;

namespace Test2.Configurations
{
    public class CarEntityConfiguration: IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(e => e.IdCar);
            builder.Property(e => e.IdCar).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ProductionYear).IsRequired().HasColumnType("integer");

            var cars = new List<Car>();

            cars.Add(new Car
            {
                IdCar = 1,
                Name = "A",
                ProductionYear = 2000
            });

            cars.Add(new Car
            {
                IdCar = 2,
                Name = "B",
                ProductionYear = 2001
            });

            cars.Add(new Car
            {
                IdCar = 3,
                Name = "C",
                ProductionYear = 2002
            });

            builder.HasData(cars);
        }
    }
}
