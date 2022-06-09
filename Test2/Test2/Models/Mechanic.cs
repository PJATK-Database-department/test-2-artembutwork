namespace Test2.Models
{
    public class Mechanic
    {
        public Mechanic()
        {
            Inspections = new HashSet<Inspection>();
        }

        public int IdMechanic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
