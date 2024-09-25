namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class Department
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Department() { } 

    public Department(string name)
    {
        Name = name;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}