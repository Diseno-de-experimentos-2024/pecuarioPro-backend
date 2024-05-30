namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<District> Districts { get; set; }

    public City()
    {
        Districts = new List<District>();
    }

    public City(string name)
    {
        Name = name;
        Districts = new List<District>();
    }
}