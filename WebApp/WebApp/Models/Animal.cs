namespace WebApp.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public EAnimal Type { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }

    public void update(Animal _animal)
    {
        IdAnimal = _animal.IdAnimal;
        Name = _animal.Name;
        Type = _animal.Type;
        Weight = _animal.Weight;
        Color = _animal.Color;
    }
}