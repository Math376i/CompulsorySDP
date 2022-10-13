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

    public List<Box> GetAllBoxes()
    {
        return _boxRepository.GetAllBoxes();
    }

    public Box CreateNewBox(BoxDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());


        return _boxRepository.CreateNewBox(_mapper.Map<Box>(dto));
    }

    public Box GetBoxById(int id)
    {
        return _boxRepository.GetBoxById(id);
    }

    public void RebuildDB()
    {
        _boxRepository.RebuildDB();
    }

    public Box UpdateBox(int id, Box box)
    {
        if (id != box.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _boxValidator.Validate(box);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _boxRepository.UpdateBox(box);
    }

    public Box DeleteBox(int id)
    {
        return _boxRepository.DeleteBox(id);
    }
}