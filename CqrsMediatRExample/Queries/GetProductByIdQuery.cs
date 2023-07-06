using MediatR;

namespace CqrsMediatRExample.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
