using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Entities;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class BoxService : IBoxService
{
    private IBoxRepository _boxRepository;
    private IMapper _mapper;
    private IValidator<BoxDTOs> _postValidator;
    private IValidator<Box> _boxValidator;


    public BoxService(IBoxRepository repository, IMapper mapper, IValidator<BoxDTOs> postValidator, IValidator<Box> boxValidator)
    {
        _boxRepository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
        _boxValidator = boxValidator;
    }
// The method create a list of all the box
    public List<Box> GetAllBoxes()
    {
        return _boxRepository.GetAllBoxes();
    }

    // The methods helps to create a new box
    public Box CreateNewBox(BoxDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());


        return _boxRepository.CreateNewBox(_mapper.Map<Box>(dto));
    }

    // The method helps to get the box by the id
    public Box GetBoxById(int id)
    {
        return _boxRepository.GetBoxById(id);
    }
// The method helps to rebuild the database
    public void RebuildDB()
    {
        _boxRepository.RebuildDB();
    }
// The method helps to update a box
    public Box UpdateBox(int id, Box box)
    {
        if (id != box.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _boxValidator.Validate(box);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _boxRepository.UpdateBox(box);
    }
// The method helps to delete a box
    public Box DeleteBox(int id)
    {
        return _boxRepository.DeleteBox(id);
    }
}