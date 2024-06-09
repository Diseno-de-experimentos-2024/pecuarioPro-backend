using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates
{
    public  class Vaccines
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Reason { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        
        public Vaccines(int id, string name, string reason, string code, string description)
        {
            Id = id;
            Name = name;
            Reason = reason;
            Code = code;
            Description = description;
        }
        
        public Vaccines(CreateVaccineCommand command)
        {
            Name = command.Name;
            Reason = command.Reason;
            Code = command.Code;
            Description = command.Description;
        }
        /*
         public Vaccines(UpdateVaccineCommand command)
        {
            Id = command.Id;
            Name = command.Name;
            Reason = command.Reason;
            Code = command.Code;
            Description = command.Description;
        }
        public Vaccines(DeleteVaccineCommand command)
        {
            Id = command.Id;
        }*/
        
    }
}

