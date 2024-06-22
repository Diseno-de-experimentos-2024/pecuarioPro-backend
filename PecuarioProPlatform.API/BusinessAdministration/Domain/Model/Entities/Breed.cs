namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public class Breed
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Breed(){}

    public Breed(string name)
    {
        Name = name;
    }
    
    
    // public Race(CreateRaceCommand command): this(command.Name){}
}