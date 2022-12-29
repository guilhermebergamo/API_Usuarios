using Microsoft.EntityFrameworkCore;
using Teste.Usuarios.Domain.Contracts.v1.Repositories;
using Teste.Usuarios.Domain.Entities.v1;
using Teste.Usuarios.Domain.Models.v1;
using Teste.Usuarios.Infra.SqlServer.Context;

namespace Teste.Usuarios.Infra.SqlServer.Repositories.v1
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            await _context.Usuarios!.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuario(Guid id)
        {
            var usuario = await _context.Usuarios!.FindAsync(id);

            if(usuario is null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterUsuario(Guid id)
        {
            var usuario = await _context.Usuarios!.FindAsync(id);
            
            if (usuario is null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            return usuario;
        }
            
        public async Task<List<Usuario>> ObterUsuarios(UsuarioFilterModel usuarioFilterModel)
        {
            var usuarios = await _context.Usuarios!
                .Where(usuario => usuario.Nome.Equals(usuarioFilterModel.Nome)
                || usuario.Cpf.Equals(usuarioFilterModel.Cpf)
                || usuario.Sobrenome.Equals(usuarioFilterModel.Sobrenome)
                ).ToListAsync();        

            return usuarios.ToList();

        }
    }
}
