namespace FleetTracker.Contexts.Auth.Domain.ValueObjects
{
    public class DocumentCnh : ValueObject
    {
        public string number { get; private set; }

        public DocumentCnh(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("A CNH não pode estar vazia.", nameof(number));

            var normalizedNumber = new string(number.Where(char.IsDigit).ToArray()); //Mantém apenas números

            if (normalizedNumber.Length != 11)
                throw new ArgumentException("A CNH deve conter exatamente 11 dígitos.", nameof(number));

            if (!IsValidCnh(normalizedNumber))
                throw new ArgumentException("O número da CNH informada é inválido.", nameof(number));

            this.number = normalizedNumber;
        }

        private bool IsValidCnh(string cnh) //Algoritmo oficial de validação de CNH
        {
            if (cnh.All(c => c == cnh[0])) // Rejeita sequências repetidas como 11111111111
                return false;

            int d1 = 0, d2 = 0, v1 = 0, v2 = 0;

            for (int i = 0, j = 9; i < 9; i++, j--)
            {
                d1 += (cnh[i] - '0') * j;
                d2 += (cnh[i] - '0') * (10 - j);
            }

            v1 = d1 % 11;
            if (v1 >= 10)
            {
                v1 = 0;
                d2 += 2;
            }

            v2 = d2 % 11;
            if (v2 >= 10)
                v2 = 0;
            
            return v1 == (cnh[9] - '0') && v2 == (cnh[10] - '0'); // Verifica se os dígitos calculados batem com os dois últimos da string
        }
        protected override IEnumerable<object> GetEqualityComponents() //Diz à classe base ValueObject quais propriedades definem igualdade
        {
            yield return number;
        }

        public override string ToString()
        {
            return number;
        }
    }
}
