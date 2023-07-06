using MediatR;

namespace CqrsMediatRExample.Commands
{
    public record DeleteProductCommand(int id) : IRequest<Unit>;
}
