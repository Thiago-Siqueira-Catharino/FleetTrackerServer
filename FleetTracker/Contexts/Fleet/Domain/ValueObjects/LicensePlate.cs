using FleetTracker.Common.ValueObjects;

using System.Text.RegularExpressions;

namespace FleetTracker.Contexts.Fleet.Domain.ValueObjects
{
    public class LicensePlate : ValueObject
    {
        public string value { get; private set; }

        public LicensePlate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O valor da placa não pode estar vazio.", nameof(value));

            var normalizedValue = value.ToUpperInvariant().Replace("-", "").Trim(); //Tira o traço

            var regex = new Regex(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$"); //Valida o formato de placa Mercosul e o formato antigo, peguei na net

            if (!regex.IsMatch(normalizedValue))
                throw new ArgumentException("O formato da placa é inválido.", nameof(value)); //Compara se é válido com o formato em regex

            this.value = normalizedValue;
        }

        protected override IEnumerable<object> GetEqualityComponents() //Diz à classe base ValueObject quais propriedades definem igualdade
        {
            yield return this.value;
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}
