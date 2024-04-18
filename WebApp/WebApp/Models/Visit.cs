namespace WebApp.Models;

public class Visit
{
    public int IdVisit { get; set; }
    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public String Description { get; set; }
    public double Cost { get; set; }
}