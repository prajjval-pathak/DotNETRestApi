using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApi.Dto;
using RestApi.Interface;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_repository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            var exist = _repository.CategoryExist(id);
            if (exist) {
                var Category = _mapper.Map<CategoryDto>(_repository.GetCategory(id));
                if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
                }
                return Ok(Category);
            }
            return NotFound();
        }
        [HttpGet("PokemonByCategory/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int id)
        {
            var exist = _repository.CategoryExist(id);
            if (exist)
            {
                var Category = _mapper.Map<List<PokemonDto>>(_repository.GetPokemonByCategory(id));
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(Category);
            }
            return NotFound();
        }
    }
}
