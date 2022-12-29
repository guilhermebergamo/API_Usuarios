using MediatR;

namespace Teste.Usuarios.Domain.Commands
{
    public abstract class Command: IRequest<Unit>
    {
    }
}
