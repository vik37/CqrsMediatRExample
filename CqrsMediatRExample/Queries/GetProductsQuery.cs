using MediatR;

namespace CqrsMediatRExample.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
