using Microsoft.AspNetCore.Mvc;
using Test2.Models;

namespace Test2.Service
{
    public interface IDbService
    {

        IActionResult GetInspections();

        IActionResult UpdateCar(Car car);
    }
}
