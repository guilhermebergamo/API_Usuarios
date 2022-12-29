using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Usuarios.Domain.Entities.v1;

namespace Teste.Usuarios.Infra.SqlServer.Context
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TesteUsuario");
        }

        public DbSet<Usuario>? Usuarios { get; set; }
    }
}
