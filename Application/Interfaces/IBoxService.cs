using Application.DTOs;
using Entities;

namespace Application.Interfaces;

// The interface helps to implements the methods 
public interface IBoxService
{
    public List<Box> GetAllBoxes();
    public Box CreateNewBox(BoxDTOs dto);
    public Box GetBoxById(int id);
    public void RebuildDB();
    public Box UpdateBox(int Id, Box box);
    public Box DeleteBox(int Id);
}