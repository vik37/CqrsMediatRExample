using CqrsMediatRExample.Queries;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    public class GetProductsHadler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductsHadler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            => await _fakeDataStore.GetAllProducts();
    }
}
