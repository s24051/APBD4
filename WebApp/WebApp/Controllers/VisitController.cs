using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<Visit> _visits= new()
    {
        new Visit { IdVisit = 1, Animal = AnimalController.getAnimal(1), Date = new DateTime(2024, 04,18,20,15,00), Description = "Ok", Cost = 125},
        new Visit { IdVisit = 1, Animal = AnimalController.getAnimal(2), Date = new DateTime(2024, 04,18,19,15,00), Description = "Złamana łapa.", Cost = 250},
        new Visit { IdVisit = 1, Animal = AnimalController.getAnimal(1), Date = new DateTime(2024, 04,16,15,15,00), Description = "Do ponowienia.", Cost = 75},    }; 
    
    [HttpGet]
    public IActionResult GetVisits([FromQuery(Name = "name")] string name)
    {
        return Ok(_visits.FindAll(animal => animal.Animal.Name == name));
    }

    [HttpPost]
    public IActionResult PostVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}