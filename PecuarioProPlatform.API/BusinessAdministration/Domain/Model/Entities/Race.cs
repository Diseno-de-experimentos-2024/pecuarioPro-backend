namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

public class Race(string name)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;

    public Race():this(string.Empty){}
    
    // public Race(CreateRaceCommand command): this(command.Name){}
}