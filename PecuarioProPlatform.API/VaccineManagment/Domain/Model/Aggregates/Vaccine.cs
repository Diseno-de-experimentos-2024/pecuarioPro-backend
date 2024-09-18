using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.valueobjects;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates
{
    /**
     * Entidad raíz del agregado de vacuna.
     *
     * <p>
     * Esta clase representa la entidad raíz del agregado de vacuna. Contiene las propiedades y métodos para gestionar la vacuna.
     * </p>
     */
    public partial class Vaccine
    {
        // Constructor por defecto que inicializa las propiedades con valores predeterminados.
        public Vaccine()
        {
            Name = string.Empty;
            Date = DateOnly.FromDateTime(DateTime.Now); // Provide a default DateTime value
            Code = string.Empty;
            Reason = string.Empty;
        }

        public Vaccine(int id, string name, DateOnly date, string code, string reason,double dose, int userId, int bovineId)
        {
            Id = id;
            Name = name;
            Date = date;
            Code = code;
            Reason = reason;
            Dose = dose;
            UserId = new UserId(userId);
            BovineId = new BovineId(bovineId);
        }

        // Constructor que inicializa las propiedades utilizando un comando CreateVaccineCommand.
        public Vaccine(CreateVaccineCommand command)
        {
            Name = command.Name;
            Date = command.Date;
            Code = command.Code;
            Reason = command.Reason;
            Dose = command.Dose;
            UserId = new UserId(command.UserId);
            BovineId = new BovineId(command.BovineId);
        }
        
        public void updateInformation(string Name, DateOnly Date, string Code, string Reason,double Dose)
        {
            this.Name = Name;
            this.Date = Date;
            this.Code = Code;
            this.Reason = Reason;
            this.Dose = Dose;
        }
        
        // Constructor que inicializa las propiedades utilizando un comando DeleteVaccineCommand.
        public Vaccine(DeleteVaccineCommand command)
        {
            Id = command.Id;
        }

        // Propiedades de la clase Vaccine.
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly Date { get; private set; }
        public string Code { get; private set; }
        public string Reason { get; private set; }
        
        public Double Dose { get; private set; }
        
        public UserId UserId { get; private set; }
        
        public BovineId BovineId { get; private set; }

        // Propiedad que devuelve una descripción completa de la vacuna.
        public string FullDescription => $"{Code}: {Name} - {Reason} on {Date}";
    }
}