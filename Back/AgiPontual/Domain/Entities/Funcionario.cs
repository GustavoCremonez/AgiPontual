using Domain.Contracts.Enums;

namespace Domain.Entities
{
    public class Funcionario
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Registro { get; set; }

        public Cargos Cargo { get; set; }
    }
}
