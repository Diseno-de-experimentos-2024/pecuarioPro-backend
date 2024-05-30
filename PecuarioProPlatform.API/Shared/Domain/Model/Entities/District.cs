namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class District
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    
    public District()
    {
    }

    public District(string name, int cityId)
    {
        Name = name;
        CityId = cityId;
    }
}