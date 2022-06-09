namespace Test2.Models
{
    public class ServiceTypeDict
    {
        public ServiceTypeDict()
        {
            ServiceTypeDictInspections = new HashSet<ServiceTypeDictInspection>();
        }

        public int IdServiceType { get; set; }
        public string ServiceType { get; set; }
        public double Price { get; set; }

        public virtual ICollection<ServiceTypeDictInspection> ServiceTypeDictInspections { get; set; }

    }
}
