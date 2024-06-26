using System.Text.RegularExpressions;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.valueobjects
{
    public record VaccineCode
    {
        private static readonly Regex CodeRegex = new Regex("^[A-Za-z]{3}\\d{3}$", RegexOptions.Compiled);

        public string Value { get; init; }

        public VaccineCode(string value)
        {
            if (!IsValidCode(value))
            {
                throw new ArgumentException("Invalid vaccine code format. The code must start with three letters followed by three numbers.");
            }
            Value = value;
        }

        private static bool IsValidCode(string value)
        {
            return CodeRegex.IsMatch(value);
        }

        public override string ToString() => Value;
    }
}