using API.DTOs;
using AutoMapper;
using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{

    private BoxRepository _boxRepository;
    private ProductValidator _productValidator;
    private IMapper _mapper;
    
    public ProductController(ProductRepository repository, IMapper mapper)
    {
        _productValidator = new ProductValidator();
        _productRepository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    [HttpPost]
    public ActionResult CreateNewProduct(PostProductDTO dto)
    {
        ProductValidator validator = new ProductValidator();
        var validation = _productValidator.Validate(dto);
        if (validation.IsValid)
        {
           
            Product product = _mapper.Map<Product>(dto);
            return Ok(_productRepository.InsertProduct(product));
        }
        return BadRequest(validation.ToString());
    }

    [HttpGet]
    [Route("CreateDB")]
    public string CreateDB()
    {
        _productRepository.CreateDB();
        return "Db has been created";
    }
    
}