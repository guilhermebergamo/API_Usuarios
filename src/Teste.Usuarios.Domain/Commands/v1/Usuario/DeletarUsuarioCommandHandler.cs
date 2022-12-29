
using MediatR;
using Teste.Usuarios.Domain.Contracts.v1.Repositories;

namespace Teste.Usuarios.Domain.Commands.v1.Usuario
{
    public class DeletarUsuarioCommandHandler : CommandHandler<DeletarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DeletarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public override async Task<Unit> Handle(DeletarUsuarioCommand command, CancellationToken cancellationToken)
        {
            await _usuarioRepository.DeletarUsuario(command.Id);

            return Unit.Value;
        }
    }
}