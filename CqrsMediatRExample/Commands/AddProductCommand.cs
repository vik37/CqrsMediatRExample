using MediatR;

namespace CqrsMediatRExample.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;
}
