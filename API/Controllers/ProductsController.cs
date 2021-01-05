using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {


        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
         IGenericRepository<ProductType> productTypeRepo,
         IGenericRepository<ProductBrand> productBrandRepo,
         IMapper mapper)
        {
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrands();

            var products = await _productRepo.ListAsync(spec);

            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),  StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrands(id);

            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null)
                return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.GetAllAsync());
        }
    }
}