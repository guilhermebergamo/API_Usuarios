
using AutoMapper;
using MediatR;
using Teste.Usuarios.Domain.Contracts.v1.Repositories;

namespace Teste.Usuarios.Domain.Commands.v1.Usuario
{
    public class AtualizarUsuarioCommandHandler : CommandHandler<AtualizarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public override async Task<Unit> Handle(AtualizarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Entities.v1.Usuario>(command.UsuarioDto);
            await _usuarioRepository.AtualizarUsuario(usuario);

            return Unit.Value;
        }
    }
}