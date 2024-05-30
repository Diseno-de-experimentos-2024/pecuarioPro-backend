namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Bovine
{
    public ICollection<Vaccine> Vaccines { get; }

    public Bovine()
    {
        Vaccines = new List<Vaccine>();
    }
    
    
}