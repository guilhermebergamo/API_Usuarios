using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Usuarios.Domain.Dtos.v1;
using Teste.Usuarios.Domain.Models.v1;

namespace Teste.Usuarios.Domain.Queries.v1.Usuario
{
    public class ObterUsuariosQuery : IRequest<List<UsuarioDto>>
    {
        public ObterUsuariosQuery(UsuarioFilterModel usuarioFilterModel)
        {
            UsuarioFilterModel = usuarioFilterModel;
        }

        public UsuarioFilterModel UsuarioFilterModel { get; set; }
    }
}
