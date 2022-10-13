using Application.Interfaces;
using Entities;

namespace Infrastructure;


    public class BoxRepository : IBoxRepository
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

        public List<Box> GetAllBoxes()
        {
            throw new NotImplementedException();
        }

        public Box CreateNewBox(Box box)
        {
            throw new NotImplementedException();
        }

        public Box GetBoxById(int id)
        {
            throw new NotImplementedException();
        }

        public void RebuildDB()
        {
            throw new NotImplementedException();
        }

        public Box UpdateBox(Box box)
        {
            throw new NotImplementedException();
        }

        public Box DeleteBox(int id)
        {
            throw new NotImplementedException();
        }
    }
