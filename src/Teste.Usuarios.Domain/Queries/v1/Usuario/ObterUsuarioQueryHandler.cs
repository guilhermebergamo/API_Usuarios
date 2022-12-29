using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Usuarios.Domain.Contracts.v1.Repositories;
using Teste.Usuarios.Domain.Dtos.v1;

namespace Teste.Usuarios.Domain.Queries.v1.Usuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, UsuarioDto>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public ObterUsuarioQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterUsuario(request.Id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return usuarioDto;
        }
    }
}
