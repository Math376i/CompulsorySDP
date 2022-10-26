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
    private IMapper _mapper;
    
    public BoxController(IMapper mapper, IBoxService service)
    {
        _boxService = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Route("GetAllBoxes")]
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
            return Created("box/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
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

    [HttpPut]
    public ActionResult<Box> UpdateBox([FromBody] Box box)
    {
        try
        {
            return Ok(_boxService.UpdateBox(box.Id ,box));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID " + box.Id);
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
    [Route("RebuildDB")]
    public string RebuildDB()
    {
        _boxService.RebuildDB();
        return "Db has been created";
    }
    
}