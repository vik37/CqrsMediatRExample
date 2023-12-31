﻿namespace CqrsMediatRExample
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product{Id = 1, Name = "Test 1"},
                new Product{Id = 2, Name = "Test 2"},
                new Product{Id = 3, Name = "Test 3"}
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products.OrderBy(x => x.Id)); 

        public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.Single(x => x.Id == id));

        public async Task UpdateProduct(Product product)
        {
            var productForRemove = _products.Single(x => x.Id== product.Id);
            _products.Remove(productForRemove);
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task DeleteProduct(int id)
        {
            var product =  _products.Single(x => x.Id == id);
            _products.Remove(product);
            await Task.CompletedTask;
        }

        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(x => x.Id == product.Id).Name = $"{product.Name} event: {evt}";
            await Task.CompletedTask;
        }
    }
}
