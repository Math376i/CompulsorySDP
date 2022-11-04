using Entities;

namespace Application.Interfaces;
// The interface helps to implement all the methods
public interface IBoxRepository
{
    public List<Box> GetAllBoxes();
    public Box CreateNewBox(Box box);
    public Box GetBoxById(int id);
    public void RebuildDB();
    public Box UpdateBox(Box box);
    public Box DeleteBox(int id);
}