namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public class Race
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Race(){}

    public Race(string name)
    {
        Name = name;
    }
    
    
    // public Race(CreateRaceCommand command): this(command.Name){}
}