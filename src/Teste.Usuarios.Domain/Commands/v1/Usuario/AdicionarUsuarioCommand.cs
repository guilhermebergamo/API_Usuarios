
using Teste.Usuarios.Domain.Dtos.v1;

namespace Teste.Usuarios.Domain.Commands.v1.Usuario
{
    public class AdicionarUsuarioCommand : Command
    {
        public AdicionarUsuarioCommand(UsuarioDto usuarioDto)
        {
            UsuarioDto = usuarioDto;
        }

        public UsuarioDto UsuarioDto { get; set; }
    }
}
