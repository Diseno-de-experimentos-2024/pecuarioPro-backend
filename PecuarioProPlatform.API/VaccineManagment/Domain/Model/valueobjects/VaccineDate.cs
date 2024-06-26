namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.ValueObjects
{
    public class VaccineDate
    {
        public DateTime Value { get; private set; }

        public VaccineDate(DateTime value)
        {
            Value = value;
        }

        public static implicit operator DateTime(VaccineDate vaccineDate)
        {
            return vaccineDate.Value;
        }

        public static explicit operator VaccineDate(DateTime dateTime)
        {
            return new VaccineDate(dateTime);
        }
    }
}