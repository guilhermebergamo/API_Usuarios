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
    public class ObterUsuariosQueryHandler : IRequestHandler<ObterUsuariosQuery, List<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public ObterUsuariosQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDto>> Handle(ObterUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterUsuarios(request.UsuarioFilterModel);
            var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuario);

            return usuariosDto;
        }
    }
}
