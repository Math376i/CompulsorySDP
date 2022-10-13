using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Entities;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class BoxController : ControllerBase
{
    private IBoxService _boxService;
    private BoxRepository _boxRepository;
    private BoxValidator _boxValidator;
    private IMapper _mapper;
    
    public BoxController(BoxRepository repository, IMapper mapper, IBoxService service)
    {
        _boxService = service;
        _boxValidator = new BoxValidator();
        _boxRepository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public List<Box> GetBox()
    {
        return _boxService.GetAllBoxes();
    }

    [HttpPost]
    public ActionResult CreateNewBox(BoxDTOs dto)
    {
        try
        {
            var result = _boxService.CreateNewBox(dto);
            return Created("product/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
        BoxValidator validator = new BoxValidator();
        var validation = _boxValidator.Validate(dto);
        if (validation.IsValid)
        {
           
            Box product = _mapper.Map<Box>(dto);
            return Ok(_boxRepository.InsertProduct(product));
        }
        return BadRequest(validation.ToString());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Box> GetBoxById(int id)
    {
        try
        {
            return _boxService.GetBoxById(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpGet]
    [Route("RebuildDB")]
    public void RebuildDB()
    {
        _boxService.RebuildDB();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<Box> UpdateBox([FromRoute] int id, [FromBody] Box box)
    {
        try
        {
            return Ok(_boxService.UpdateBox(id, box));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Box> DeleteBox(int id)
    {
        try
        {
            return Ok(_boxService.DeleteBox(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID " + id);
        }
    }

    [HttpGet]
    [Route("CreateDB")]
    public string CreateDB()
    {
        _boxRepository.CreateDB();
        return "Db has been created";
    }
    
}