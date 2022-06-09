namespace Test2.Models.DTO.Response
{
    public class InspectionDTO
    {
        public CarDTO Car { get; set; }

        public MechanicDTO Mechanic { get; set; }

        public ICollection<ServiceTypeDTO> Services { get; set; }
    }
}
