using LibraryA_01.Domain;
using LibraryA_01.Dtos;
using LibraryA_01.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LibraryA_01.UseCase
{
    public class BookUseCase
    {
        private readonly AppDbContext _context;
        public BookUseCase(AppDbContext context)
        {
            _context = context;
        }
        public async Task<BookDto> Create(CreateBookDto request)
        {
            var newBook = new Book(request.Title, request.Author, request.ISBN, request.Year, request.NumberOfPages, request.Available);

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return MapToDto(newBook);
        }
        public async Task<string?> Update(Guid id, UpdateBookDto request)
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null)
            {
                return $"Book with ID {id} not found.";
            }
            book.Update(request.Title, request.Author, request.ISBN, request.Year, request.NumberOfPages, request.Available);
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task<string?> Delete(Guid id)
        {
            
            var book = await _context.Books.FindAsync(id);
            if(book == null)
            {
                return $"Book with ID {id} not found.";
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return books.Select(MapToDto);
        }
        public async Task<BookDto?> GetById(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null)
            {
                return null;
            }
            return MapToDto(book);
        }
        private static BookDto MapToDto(Book book) => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            Year = book.Year,
            NumberOfPages = book.NumberOfPages,
            Available = book.Available
        };
    }
}
