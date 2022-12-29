using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Usuarios.Domain.Dtos.v1;

namespace Teste.Usuarios.Domain.Queries.v1.Usuario
{
    public class ObterUsuarioQuery : IRequest<UsuarioDto>
    {
        public ObterUsuarioQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
