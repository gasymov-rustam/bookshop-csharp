using BookShop.Domain.Entities;
using BookShop.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IEFRepository<Author> _repository;
        public AuthorController(IEFRepository<Author> repository)
        {
            _repository = repository;
        }

        [HttpGet("authors")]
        public async ValueTask<IActionResult> GetAllAuthors() => Ok(await _repository.GetAll());

        //[HttpGet("author")]
        //public async ValueTask<IActionResult> GetAuthorById(Guid id) => Ok(await _repository.GetById(id));

        [HttpPost("author")]
        public async ValueTask<IActionResult> AddNewAuthor([FromBody] Author author) => Ok(await _repository.Add(author));

        [HttpGet("author")]
        public async ValueTask<IActionResult> GetByCondition(string name) => Ok(await _repository.GetByCondition(x => x.Name == name));

        //[HttpPut("author")]
        //public async ValueTask<IActionResult> AddNewAuthor([FromBody] Author author) => Ok(await _repository.Add(author));
    }
}
