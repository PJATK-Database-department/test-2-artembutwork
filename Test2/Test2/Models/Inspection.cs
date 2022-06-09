namespace Test2.Models
{
    public class Inspection
    {
        public Inspection()
        {
            ServiceTypeDictInspections = new HashSet<ServiceTypeDictInspection>();
        }

        public int IdInspection { get; set; }

        public int IdCar { get; set; }
        public int IdMechanic { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Comment { get; set; }
        

        public virtual Car IdCarNavigation { get; set; }
        public virtual Mechanic IdMechanicNavigation { get; set; }

        public virtual ICollection<ServiceTypeDictInspection> ServiceTypeDictInspections { get; set; }
    }
}
