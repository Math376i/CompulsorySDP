using API.DTOs;
using AutoMapper;
using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class BoxController : ControllerBase
{

    private BoxRepository _boxRepository;
    private BoxValidator _boxValidator;
    private IMapper _mapper;
    
    public BoxController(BoxRepository repository, IMapper mapper)
    {
        _boxValidator = new BoxValidator();
        _boxRepository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public List<Box> GetProducts()
    {
        return _boxRepository.GetAllProducts();
    }

    [HttpPost]
    public ActionResult CreateNewProduct(PostBoxDTO dto)
    {
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
    [Route("CreateDB")]
    public string CreateDB()
    {
        _boxRepository.CreateDB();
        return "Db has been created";
    }
    
}