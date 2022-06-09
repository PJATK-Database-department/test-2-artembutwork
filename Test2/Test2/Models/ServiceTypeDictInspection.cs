namespace Test2.Models
{
    public class ServiceTypeDictInspection
    {
        public int IdServiceType { get; set; }

        public int IdInspection { get; set; }
        public string Comments { get; set; }

        public virtual ServiceTypeDict IdServiceTypeDictNavigation { get; set; }
        public virtual Inspection IdInspectionNavigation { get; set; }

    }
}
