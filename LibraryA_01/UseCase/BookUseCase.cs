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
            try
            {
                var newBook = new Book(request.Title, request.Author, request.ISBN, request.Year, request.NumberOfPages, request.Available);

                await _context.Books.AddAsync(newBook);
                await _context.SaveChangesAsync();

                return MapToDto(newBook);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating book: {ex.Message}");
            }
        }
        public async Task Update(UpdateBookDto request)
        {
            try
            {
                var book = await _context.Books.FindAsync(request.Id);
                if(book != null)
                {
                    throw new Exception($"Book with ID {request.Id} not found.");
                }
                book.Update(request.Title, request.Author, request.ISBN, request.Year, request.NumberOfPages, request.Available);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                throw new Exception($"Error updating book: {ex.Message}");
            }
        }
        public async Task Delete(Guid id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if(book != null)
                {
                    throw new Exception($"Book with ID {id} not found.");
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception($"Error deleting book: {ex.Message}");
            }
        }
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return books.Select(MapToDto);
            }catch(Exception ex)
            {
                throw new Exception($"Error retrieving books: {ex.Message}");
            }
        }
        public async Task<BookDto> GetById(Guid id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if(book == null)
                {
                    throw new Exception($"Book with ID {id} not found.");
                }
                return MapToDto(book);
            }catch(Exception ex)
            {
                throw new Exception($"Error retrieving book: {ex.Message}");
            }
        }
        private static BookDto MapToDto(Book book) => new BookDto
        {
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            Year = book.Year,
            NumberOfPages = book.NumberOfPages,
            Available = book.Available
        };
    }
}
