
using Teste.Usuarios.Domain.Dtos.v1;

namespace Teste.Usuarios.Domain.Commands.v1.Usuario
{
    public class AtualizarUsuarioCommand : Command
    {
        public AtualizarUsuarioCommand(UsuarioDto usuarioDto)
        {
            UsuarioDto = usuarioDto;
        }

        public UsuarioDto UsuarioDto { get; set; }
    }
}
