namespace Teste.Usuarios.Domain.Entities.v1
{
    public class Usuario
    {
        public Usuario(string? nome, string? sobrenome, string? cpf, DateTime? dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }    
        public string? Sobrenome { get; set; }
        public string? Cpf { get; set; }     
        public DateTime? DataNascimento { get; set; }

    }
}