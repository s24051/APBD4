using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    // "baza" i mocki;
    private static readonly List<Animal> _animals = new()
    {
        new Animal {IdAnimal = 1, Name = "Burek", Type = EAnimal.DOG, Weight = 5.2, Color = "Brązowy"},
        new Animal {IdAnimal = 2, Name = "Kitka", Type = EAnimal.CAT, Weight = 2.3, Color = "Czarno-Biały"},
        new Animal {IdAnimal = 3, Name = "Szarek", Type = EAnimal.RABBIT, Weight = 1.1, Color = "Szary"},
        new Animal {IdAnimal = 4, Name = "Jarek", Type = EAnimal.GUINEA_PIG, Weight = 0.7, Color = "Beżowe ciapki"},
    };

    public static Animal? getAnimal(int id)
    {
        return _animals.Find(animal => animal.IdAnimal == id);
    }

    /*** GET&POST /animals ***/
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpPost]
    public IActionResult PostAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /*** GET|PUT|DELETE /animals/{id} ***/
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = getAnimal(id);
        if (animal == null)
            return NotFound($"Animal {id} not found!");
        return Ok(animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult updateAnimal(int id, Animal _animal)
    {
        var animal = getAnimal(id);
        if (animal == null)
            return NotFound($"Animal {id} not found!");
        animal.update(_animal);
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = getAnimal(id);
        if (animal == null)
            return NotFound($"Animal {id} not found!");
        _animals.Remove(animal);
        return StatusCode(StatusCodes.Status200OK);
    }
}