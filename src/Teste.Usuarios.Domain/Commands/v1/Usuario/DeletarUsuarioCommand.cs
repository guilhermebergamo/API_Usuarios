
namespace Teste.Usuarios.Domain.Commands.v1.Usuario
{
    public class DeletarUsuarioCommand : Command
    {
        public DeletarUsuarioCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
