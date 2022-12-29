using Teste.Usuarios.Domain.Entities.v1;
using Teste.Usuarios.Domain.Models.v1;

namespace Teste.Usuarios.Domain.Contracts.v1.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObterUsuarios(UsuarioFilterModel usuarioFilterModel);
        Task<Usuario> ObterUsuario(Guid id);
        Task AdicionarUsuario(Usuario usuario);
        Task AtualizarUsuario(Usuario usuario);
        Task DeletarUsuario(Guid id);
    }
}