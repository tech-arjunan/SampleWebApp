using SampleWebApp.Models;

namespace SampleWebApp.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private List<Product> _products = new List<Product>();

        public List<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            return _products.Find(p => p.Id == id);
        }
        public void Add(Product entity)
        {
            _products.Add(entity);
        }
    }
}
