using Entities;

namespace Infrastructure;
public class Class1
{
    public class BoxRepository
    {
        private BoxDbContext _boxContext;

        public BoxRepository(BoxDbContext context)
        {
            _boxContext = context;
        }

        public List<Box> GetAllProducts()
        {
            return _boxContext.ProductTable.ToList();
        }

        public Product InsertProduct(Product product)
        {
            _productContext.ProductTable.Add(product);
            _productContext.SaveChanges();
            return product;
        }

        public void CreateDB()
        {
            _productContext.Database.EnsureDeleted();
            _productContext.Database.EnsureCreated();
        
        }
    
    }
}