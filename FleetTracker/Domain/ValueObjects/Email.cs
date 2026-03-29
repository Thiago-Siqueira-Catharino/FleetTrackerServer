namespace FleetTracker.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string emailAddress { get; private set; }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail não pode estar vazio.", nameof(email));

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Regras de sintaxe de email

            if (!regex.IsMatch(email)) //Vê se bate com regex
                throw new ArgumentException("O formato do e-mail é inválido.", nameof(email));

            this.emailAddress = email.ToLowerInvariant(); // transforma em minúsculo
        }

        protected override IEnumerable<object> GetEqualityComponents() //Diz à classe base ValueObject quais propriedades definem igualdade
        {
            yield return this.emailAddress;
        }

        public override string ToString()
        {
            return this.emailAddress;
        }
    }
}
