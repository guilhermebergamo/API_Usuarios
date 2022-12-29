using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teste.Usuarios.Domain.Commands.v1.Usuario;
using Teste.Usuarios.Domain.Dtos.v1;
using Teste.Usuarios.Domain.Models.v1;
using Teste.Usuarios.Domain.Queries.v1.Usuario;
using Teste.Usuarios.Infra.SqlServer.Context;

namespace Teste.Usuarios.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(ObterUsuarios))]
        public async Task<List<UsuarioDto>> ObterUsuarios([FromQuery]UsuarioFilterModel usuarioFilterModel)
        {
            var usuarios = await _mediator.Send(new ObterUsuariosQuery(usuarioFilterModel));
            return usuarios;
        }

        [HttpGet]
        public async Task<UsuarioDto> ObterUsuario(Guid id)
        {
            return await _mediator.Send(new ObterUsuarioQuery(id));
        }

        [HttpDelete]
        public async Task Deletar(Guid id)
        {
            await _mediator.Send(new DeletarUsuarioCommand(id));
        }

        [HttpPost]
        public async Task Adicionar(UsuarioDto usuarioDto)
        {
            await _mediator.Send(new AdicionarUsuarioCommand(usuarioDto));
        }

        [HttpPut]
        public async Task Atualizar(UsuarioDto usuarioDto)
        {
            await _mediator.Send(new AtualizarUsuarioCommand(usuarioDto));
        }
    }
}