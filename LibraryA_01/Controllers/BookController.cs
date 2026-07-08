using LibraryA_01.Dtos;
using LibraryA_01.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace LibraryA_01.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly BookUseCase _useCase;
        public BookController(BookUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("El Id es obligatorio");
            }
            var book  = await _useCase.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
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
            var book = await _useCase.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBookDto request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("El Id es obligatorio");
            }
            var result = await _useCase.Update(id, request);
            if (result != null)
            {
                return NotFound(result);
            }
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("El Id es obligatorio");
            }
            var result = await _useCase.Delete(id);
            if (result != null)
            {
                return NotFound(result);
            }
            return NoContent();
        }
    }
}
