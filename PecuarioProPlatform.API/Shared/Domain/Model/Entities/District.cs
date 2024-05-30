namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class District
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public District()
    {
    }

    public District(string name)
    {
        Name = name;
    }
}