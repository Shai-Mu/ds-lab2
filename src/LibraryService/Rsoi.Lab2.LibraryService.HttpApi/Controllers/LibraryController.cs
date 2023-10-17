using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Rsoi.Lab2.LibraryService.Core.Interfaces;
using Rsoi.Lab2.LibraryService.Core.Models.Enums;
using Rsoi.Lab2.LibraryService.Dto.Converters;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.LibraryService.HttpApi.Controllers;

public class LibraryController : ControllerBase
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly ILibraryBooksRepository _libraryBooksRepository;
    private readonly IBooksRepository _booksRepository;

    public LibraryController(ILibraryRepository libraryRepository, 
        ILibraryBooksRepository libraryBooksRepository, 
        IBooksRepository booksRepository)
    {
        _libraryRepository = libraryRepository;
        _libraryBooksRepository = libraryBooksRepository;
        _booksRepository = booksRepository;
    }

    [HttpGet]
    [Route("libraries")]
    public async Task<IActionResult> GetCityLibrariesAsync([FromQuery] [Required] string city,
        [FromQuery] int? page = null,
        [FromQuery] int? size = null)
    {
        var cityLibraries = await _libraryRepository.GetLibrariesForCity(city, page, size);

        return Ok(cityLibraries);
    }

    [HttpPost]
    [Route("libraries")]
    public async Task<IActionResult> CreateLibraryAsync([FromBody] Library library)
    {
        var libraryId = await _libraryRepository.CreateLibraryAsync(library.Name, library.City, library.Address);

        return Ok(libraryId);
    }

    [HttpPost]
    [Route("books")]
    public async Task<IActionResult> CreateBooksAsync([FromBody] Books books)
    {
        var booksId = await _booksRepository.CreateBooksAsync(books.Name, books.Genre, books.Author, books.Condition);

        return Ok(booksId);
    }

    [HttpPost]
    [Route("libraries/{libraryId}/books/{booksId}")]
    public async Task<IActionResult> CreateBooksInLibrary([FromRoute] Guid libraryId, [FromRoute] Guid booksId,
        [FromQuery] [Required] int count)
    {
        var libraryBooksId = await _libraryBooksRepository.CreateLibraryBooksAsync(booksId, libraryId, count);

        return Ok(libraryBooksId);
    }

    [HttpGet]
    [Route("libraries/{id}/books")]
    public async Task<IActionResult> GetBooksForLibrary([FromRoute] Guid id, 
        [FromQuery] int? page = null,
        [FromQuery] int? size = null,
        [FromQuery] bool? showAll = null)
    {
        var libraryBooksList = await _libraryBooksRepository.GetLibraryBooksByLibraryIdAsync(id, page, size);

        var resultBooks = new List<BooksWithCount>();
        
        foreach (var libraryBooks in libraryBooksList)
        {
            if (libraryBooks.AvailableCount > 0 || (showAll.HasValue && showAll.Value))
            {
                var books = _booksRepository.GetBooksAsync(libraryBooks.BooksId).Result;
                resultBooks.Add(BooksConverter.ConvertWithCount(books, libraryBooks.AvailableCount));
            }
        }

        return Ok(resultBooks);
    }

    [HttpGet]
    [Route("libraries/{id}")]
    public async Task<IActionResult> GetLibrary([FromRoute] Guid id)
    {
        var library = await _libraryRepository.GetLibraryAsync(id);

        return Ok(LibraryConverter.Convert(library));
    }

    [HttpGet]
    [Route("books/{id}")]
    public async Task<IActionResult> GetBooks([FromRoute] Guid id)
    {
        var books = await _booksRepository.GetBooksAsync(id);

        return Ok(BooksConverter.Convert(books));
    }

    [HttpPatch]
    [Route("libraries/{libraryId}/books/{booksId}/increment")]
    public async Task<IActionResult> IncrementBooksCount([FromRoute] Guid libraryId, [FromRoute] Guid booksId, [FromQuery]BookCondition newState)
    {
        Guid newStateBooksId;
        Guid newStateLibraryBooksId;
        
        var books = await _booksRepository.GetBooksAsync(booksId);

        var booksWithNewState =
            await _booksRepository.FindBooksWithCredentialsAsync(books.Name, books.Genre, books.Author, newState);

        if (booksWithNewState is null)
        {
            var newBooksId = await _booksRepository.CreateBooksAsync(books.Name, books.Genre, books.Author, newState);

            await _libraryBooksRepository.CreateLibraryBooksAsync(newBooksId, libraryId, 0);

            newStateBooksId = newBooksId;
        }
        else
        {
            newStateBooksId = booksWithNewState.Id;
        }
        
        var libraryBooks = await _libraryBooksRepository.FindLibraryBooksByBooksIdAndLibraryIdAsync(newStateBooksId, libraryId);

        if (libraryBooks is null)
        {
            newStateLibraryBooksId = await _libraryBooksRepository.CreateLibraryBooksAsync(newStateBooksId, libraryId, 0);
        }
        else
        {
            newStateLibraryBooksId = libraryBooks.Id;
        }

        await _libraryBooksRepository.IncrementLibraryBooksCountAsync(newStateLibraryBooksId);

        return Ok();
    }

    [HttpPatch]
    [Route("libraries/{libraryId}/books/{booksId}/decrement")]
    public async Task<IActionResult> DecrementBooksCount([FromRoute] Guid libraryId, [FromRoute] Guid booksId)
    {
        var libraryBooks = await _libraryBooksRepository.FindLibraryBooksByBooksIdAndLibraryIdAsync(booksId, libraryId);

        if (libraryBooks is null)
            return NotFound();

        if (libraryBooks.AvailableCount <= 0)
            return ValidationProblem();

        await _libraryBooksRepository.DecrementLibraryBooksCountAsync(libraryBooks.Id);

        return Ok();
    }
}