using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
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
    
    public Breed Breed { get; set; }
    public Batch Batch { get; set; }
    
    public Origin Origin { get; set; }
    public int BreedId { get; private set; }
    public int BatchId { get; private set; }

    public  UserId UserId { get; private set; }

    public Bovine(string name, double weight, DateOnly date, string observations, int breedId, int districtId,int cityId,int departmentId,int batchId,int userId):this()
    {
        Name = name;
        Weight = weight;
        Date = date;
        Observations = observations;
        Origin  = new Origin(districtId,cityId,departmentId);
        BreedId = breedId;
        BatchId = batchId;
        UserId = new UserId(userId);
        WeightRecords = new List<WeightRecord>();

        
        //When Bovine is created , the system register the first weight in WeightRecords :)
        DateTime currentDateTime = DateTime.Now;
        AddWeightRecord(Weight,currentDateTime);

    }

    public Bovine(CreateBovineCommand command):this(command.Name ,
        command.Weight, command.Date, command.Observations,
        command.BreedId,command.DistrictId,command.CityId,
        command.DepartmentId, command.BatchId,command.UserId)
    { }

    public void  updateInformation(String name, Double weight, DateOnly date, String observations, int breedId, int batchId)
    {
        this.Name = name;
        this.Weight = weight;
        this.Date = date;
        this.Observations = observations;
        this.BreedId = breedId;
        this.BatchId = batchId;
    }

    public Bovine(string name, double weight, DateOnly date, string observations, int breedId, District district,
        City city, Department department, int batchId)
    {
        Name = name;
        Weight = weight;
        Date = date;
        Observations = observations;
        Origin = new Origin(district.Id,district,city.Id,city,department.Id,department);
        BatchId = batchId;
    }
    
    public void SetWeight(double newWeight)
    {
        Weight = newWeight;
    }

    public void SetBatch(int batchId)
    {
        BatchId = batchId;
    }

}