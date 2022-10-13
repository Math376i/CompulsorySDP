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

        public List<Box> GetAllBoxes()
        {
            return _boxContext.BoxTable.ToList();
        }

        public Box CreateNewBox(Box box)
        {
            _boxContext.BoxTable.Add(box);
            _boxContext.SaveChanges();
            return box;
        }

        public void CreateDB()
        {
            _boxContext.Database.EnsureDeleted();
            _boxContext.Database.EnsureCreated();
        
        }

        public Box GetBoxById(int id)
        {
            return _boxContext.BoxTable.Find(id) ?? throw new KeyNotFoundException();
        }

        public void RebuildDB()
        {
            _boxContext.Database.EnsureDeleted();
            _boxContext.Database.EnsureCreated();
        }

        public Box UpdateBox(Box box)
        {
            _boxContext.BoxTable.Update(box);
            _boxContext.SaveChanges();
            return box;
        }

        public Box DeleteBox(int id)
        {
            var boxToDelete = _boxContext.BoxTable.Find(id) ?? throw new KeyNotFoundException();
            _boxContext.BoxTable.Remove(boxToDelete);
            _boxContext.SaveChanges();
            return boxToDelete;
        }
    }
