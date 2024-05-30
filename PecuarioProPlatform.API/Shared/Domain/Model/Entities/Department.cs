namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<City> Cities { get; set; }

    public Department()
    {
        Cities = new List<City>();
    }

    public Department(string name)
    {
        Name = name;
        Cities = new List<City>();
    }
}