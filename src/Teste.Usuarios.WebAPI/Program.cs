using MediatR;
using System.Reflection;
using Teste.Usuarios.Domain.Entities.v1;
using Teste.Usuarios.Infra.SqlServer.Context;
using Teste.Usuarios.Domain.Contracts.v1.Repositories;
using Teste.Usuarios.Infra.SqlServer.Repositories.v1;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var assembly = Assembly.GetAssembly(typeof(Usuario))!;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddTransient<ApplicationContext>();
services.AddTransient<IUsuarioRepository, UsuarioRepository>();
services.AddMediatR(assembly);
services.AddAutoMapper(assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
