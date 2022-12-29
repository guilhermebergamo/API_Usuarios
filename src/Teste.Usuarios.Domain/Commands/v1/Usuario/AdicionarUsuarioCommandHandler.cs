
using AutoMapper;
using MediatR;
using Teste.Usuarios.Domain.Contracts.v1.Repositories;

namespace Teste.Usuarios.Domain.Commands.v1.Usuario
{
    public class AdicionarUsuarioCommandHandler : CommandHandler<AdicionarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AdicionarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public override async Task<Unit> Handle(AdicionarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Entities.v1.Usuario>(command.UsuarioDto);
            await _usuarioRepository.AdicionarUsuario(usuario);

            return Unit.Value;
        }
    }
}