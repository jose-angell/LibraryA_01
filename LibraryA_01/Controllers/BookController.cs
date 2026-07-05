using LibraryA_01.Dtos;
using LibraryA_01.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace LibraryA_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookUseCase _useCase;
        public BookController(BookUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("/id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("El Id es obligatorio");
            }
            var book  = await _useCase.GetById(id);
            return Ok(book);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _useCase.GetAll();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = await _useCase.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _useCase.Update(request);
            return NoContent();
        }
        [HttpDelete("/id")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("El Id es obligatorio");
            }
            await _useCase.Delete(id);
            return NoContent();
        }
    }
}
