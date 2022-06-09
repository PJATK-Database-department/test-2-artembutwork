using Microsoft.AspNetCore.Mvc;
using Test2.Models;
using Test2.Models.DTO.Response;

namespace Test2.Service
{
    public class DbService : IDbService
    {
        private readonly Context _context;

        public DbService(Context context)
        {
            _context = context;
        }

        public IActionResult GetInspections()
        {

            List<InspectionDTO> result = new List<InspectionDTO>();

            List<Inspection> inspections = _context.Inspection.ToList();
            
            foreach(Inspection inspection in inspections)
            {
                var cars = _context.Inspection
                    .Where(row => row.IdInspection == inspection.IdInspection); ;
                var mechanics = _context.Inspection
                    .Where(row => row.IdMechanic == inspection.IdMechanic); ;
            }
            
            return Ok(result);
        }

    

        public IActionResult UpdateCar(Car car)
        {
            var checkInCar = _context.Car
                .Where(row => row.IdCar == car.IdCar);

            if (checkInCar == null)
                return BadRequest("Car doesn't exist");

            var checkInInspection = _context.Inspection
                .Where(row => row.IdCar == car.IdCar);

            if (checkInInspection == null)
                return BadRequest("Car doesn't assigned");

        }
    }
}
