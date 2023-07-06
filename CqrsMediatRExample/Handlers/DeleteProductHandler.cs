using CqrsMediatRExample.Commands;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;

        public DeleteProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;


        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.DeleteProduct(request.id);
            return Unit.Value;
        }
    }
}
