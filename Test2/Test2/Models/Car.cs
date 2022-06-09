namespace Test2.Models
{
    public class Car
    {
        public Car()
        {
            Inspections = new HashSet<Inspection>();
        }

        public int IdCar { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
