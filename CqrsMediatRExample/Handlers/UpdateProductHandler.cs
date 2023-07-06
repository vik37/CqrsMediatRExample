﻿using CqrsMediatRExample.Commands;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public UpdateProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.UpdateProduct(request.product);
            return request.product;
        }
    }
}
