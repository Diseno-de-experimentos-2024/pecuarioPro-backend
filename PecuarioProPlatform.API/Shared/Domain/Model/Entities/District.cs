namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class District
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int CityId { get; private set; }
    public City City { get; private set; }

    private District() { } 

    public District(string name, int cityId)
    {
        Name = name;
        CityId = cityId;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}