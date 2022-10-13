using Entities;

namespace Infrastructure;


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

        public Box InsertProduct(Box product)
        {
            _boxContext.ProductTable.Add(product);
            _boxContext.SaveChanges();
            return product;
        }

        public void CreateDB()
        {
            _boxContext.Database.EnsureDeleted();
            _boxContext.Database.EnsureCreated();
        
        }
    
}
