using MediatR;

namespace CqrsMediatRExample.Commands
{
    public record UpdateProductCommand(Product product) : IRequest<Product>;
}
