using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.ValueObjects;

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
            Date = new VaccineDate(DateTime.Now); // Provide a default DateTime value
            Code = string.Empty;
            Reason = string.Empty;
        }

        public Vaccine(int id, string name, VaccineDate date, string code, string reason)
        {
            Id = id;
            Name = name;
            Date = date;
            Code = code;
            Reason = reason;
        }

        // Constructor que inicializa las propiedades utilizando un comando CreateVaccineCommand.
        public Vaccine(CreateVaccineCommand command)
        {
            Name = command.Name;
            Date = new VaccineDate(command.Date);
            Code = command.Code;
            Reason = command.Reason;
        }
        
        public void updateInformation(string Name, VaccineDate Date, string Code, string Reason)
        {
            this.Name = Name;
            this.Date = Date;
            this.Code = Code;
            this.Reason = Reason;
        }
        
        // Constructor que inicializa las propiedades utilizando un comando DeleteVaccineCommand.
        public Vaccine(DeleteVaccineCommand command)
        {
            Id = command.Id;
        }

        // Propiedades de la clase Vaccine.
        public int Id { get; private set; }
        public string Name { get; private set; }
        public VaccineDate Date { get; private set; }
        public string Code { get; private set; }
        public string Reason { get; private set; }

        // Propiedad que devuelve una descripción completa de la vacuna.
        public string FullDescription => $"{Code}: {Name} - {Reason} on {Date}";
    }
}