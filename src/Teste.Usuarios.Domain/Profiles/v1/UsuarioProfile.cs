using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Usuarios.Domain.Dtos.v1;
using Teste.Usuarios.Domain.Entities.v1;

namespace Teste.Usuarios.Domain.Profiles.v1
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}