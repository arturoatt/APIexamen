using APIexamen.DTOs;
using APIexamen.Entities;
using APIexamen.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIexamen.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfwork;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfwork unitOfwork, ILogger<ProductsController> logger, IMapper mapper)
        {
            this._unitOfwork = unitOfwork;
            this._logger = logger;
            this._mapper = mapper;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync([FromQuery] PaginationDTO pagination)
        {
            IEnumerable<ProductDTO> productsDTO = null;
            try
            {
                var products = await _unitOfwork.Products.GetAllAsync(pagination);
                productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            }
            catch(Exception ex)
            {
                _logger.LogError(Resources.ErrorDB);
                return Conflict(productsDTO);
            }
            return Ok(productsDTO);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            ProductDTO productDTO = null;
            try
            {
                var product = await _unitOfwork.Products.GetAsync(id);
 
                if (product is null)
                    return NotFound();

                productDTO = _mapper.Map<ProductDTO>(product);
            }
            catch
            {
                _logger.LogError(Resources.ErrorDB);
                return Conflict();
            }            

            return Ok(productDTO);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProductAsync([FromBody] ProductDTO productDTO)
        {
            int id = 0;
            try
            {
                var product = _mapper.Map<Product>(productDTO);
                product = await _unitOfwork.Products.CreateAsync(product);
                id = product.Id;
            }
            catch
            {
                _logger.LogError(Resources.ErrorDB);
                return Conflict();
            }
            return CreatedAtRoute("GetProductAsync", id);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> PutProductAsync(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                if (id != productDTO.Id)
                    return Conflict("Ids inconsistentes");

                var product = await _unitOfwork.Products.GetAsync(id);

                if (product is null)
                    return NotFound();
            
                product = _mapper.Map<Product>(productDTO); ;
                await _unitOfwork.Products.UpdateAsync(product);
            }
            catch
            {
                _logger.LogError(Resources.ErrorDB);
                return Conflict();
            }
            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var ok = await _unitOfwork.Products.DeleteAsync(id);
                if (ok == 0)
                    return NotFound();
            }
            catch
            {
                _logger.LogError(Resources.ErrorDB);
                return Conflict();
            }         

            return Ok();
        }
    }
}
 