using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using ZstdSharp.Unsafe;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;

public partial class Bovine
{
    public int Id { get; }
    public string Name { get; private set; }
    public double Weight { get; private set; }
    public DateOnly Date { get; private set; }
    public string Observations { get; private set; }
    
    public District District { get; }
    public Race Race { get; }
    
    
    // public Vaccine Vaccine { get; }
    // public int VaccineId { get; private set; }
    
    public Batch Batch { get; }

    public int BatchId { get; private set; }
    
    public int DistrictId { get; private set; }
    public int RaceId { get; private set; }


    public Bovine(string name, double weight, DateOnly date, string observations, int districtId, int raceId)
    {
        Name = name;
        Weight = weight;
        Date = date;
        Observations = observations;
        DistrictId = districtId;
        RaceId = raceId;
        // VaccineId = vaccineId;
    }
}